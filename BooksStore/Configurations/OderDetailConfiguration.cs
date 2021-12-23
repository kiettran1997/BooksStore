using BooksStore.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Configurations
{
    public class OderDetailConfiguration : IEntityTypeConfiguration<OderDetail>
    {
        public void Configure(EntityTypeBuilder<OderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Book).WithMany(pc => pc.OrderDetails).HasForeignKey(pc => pc.BookId);
        }
    }
}

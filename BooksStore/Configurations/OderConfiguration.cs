using BooksStore.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Configurations
{
    public class OderConfiguration : IEntityTypeConfiguration<Oder>
    {
        public void Configure(EntityTypeBuilder<Oder> builder)
        {
            builder.ToTable("Oders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(pc => pc.Orders).HasForeignKey(pc => pc.CustomerId);



        }
    }
}


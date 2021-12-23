using BooksStore.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Configurations
{
    public class BookInCategoryConfiguration : IEntityTypeConfiguration<BookInCategory>
    {
        public void Configure(EntityTypeBuilder<BookInCategory> builder)
        {

            builder.ToTable("BookCategories");
            builder.HasKey(x => x.Id);
           

        }
    }
}

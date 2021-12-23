using BooksStore.Configurations;
using BooksStore.DTO;
using BooksStore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class BooksStoreDbContext : DbContext
    {
        public BooksStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure Using Fluent API
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
           //modelBuilder.ApplyConfiguration(new BookInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OderConfiguration());
            modelBuilder.ApplyConfiguration(new OderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // modelBuilder.Entity<BookInCategory>()
            //.HasOne(pc => pc.Book)
            //.WithMany(p => p.BookInCategorys);

            // modelBuilder.Entity<BookInCategory>()
            //        .HasOne(pc => pc.Category)
            //        .WithMany(c => c.BookInCategorys);

            //Data seeding
            modelBuilder.Seed();

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookInCategory> BookInCategorys { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Oder> Orders { get; set; }
        public DbSet<OderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

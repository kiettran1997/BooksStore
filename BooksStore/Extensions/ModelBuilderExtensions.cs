using BooksStore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<Author>().HasData(
               new Author
               {
                   Id = 1,
                   Name = "William",
                   
               },
               new Author
               {
                   Id = 2,
                   Name = "kiet",

               }
           );

                modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1,  Name = "Hamlet"  ,Image="",Price= 10000 ,Description = "",AuthorId = 2, PublisherId =1 , CategoryId = 1},
                new Book { Id = 2,  Name = "King Lear", Image = "", Price = 10000, Description = "" ,  AuthorId = 1 ,PublisherId = 2, CategoryId = 2},
                new Book { Id = 3,  Name = "Othello", Image = "", Price = 10000, Description = "" ,AuthorId = 1, PublisherId = 1, CategoryId = 1 }
            );
                modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Hamlet" },
                new Publisher { Id = 2, Name = "King Lear"}           
            );


            modelBuilder.Entity<Category>().HasData(
            new Category(){Id = 1 ,Name = "Tran",Image= "", Description="" },
            new Category() { Id = 2, Name = "Tuan", Image = "", Description = "" }
            );


            modelBuilder.Entity<Oder>().HasData(
            new Oder() { Id = 1, CustomerId = 1 },
            new Oder() { Id = 2, CustomerId = 2 }
            );

            modelBuilder.Entity<OderDetail>().HasData(
            new OderDetail() { Id = 1, OrderId = 1, quantity = 1, BookId = 2 } ,
            new OderDetail() { Id = 2, OrderId = 2 , quantity = 2, BookId =1}
            );

            modelBuilder.Entity<Customer>().HasData(
          new Customer() { Id = 1, Name = "x", Email = "Test", Address = "Test", PhoneNumber = "Test"  },
          new Customer() { Id = 2, Name = "Y", Email = "Test", Address = "Test", PhoneNumber = "" }
          );

        }

    }
    
}

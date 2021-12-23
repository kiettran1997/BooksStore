using AutoMapper;
using BooksStore.Controllers;
using BooksStore.DTO;
using BooksStore.Filter;
using BooksStore.Helpers;
using BooksStore.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BooksStore.Data
{
    public class CustomerManager : ICustomerRepository
    {
        private readonly BooksStoreDbContext _context;

        public CustomerManager(BooksStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

    }
}

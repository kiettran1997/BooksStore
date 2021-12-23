using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }

        public List<Role> Roles { get; } = new List<Role>();
    }
}

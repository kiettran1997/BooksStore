using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        [JsonIgnore]
        public List<User> Users { get; } = new List<User>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Helpers
{
    public class AppSettings
    {
        public const string SectionName = "JWTAuth";
        public string Secret { get; set; }
    }
}

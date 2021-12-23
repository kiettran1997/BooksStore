using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Services
{
    public static class StringExtensions
    {
        public static Stream ToStream(this string input, Encoding enc = null)
        {
            if (input is null)
            {
                throw new System.ArgumentNullException(nameof(input));
            }
            enc ??= Encoding.UTF8;

            return new MemoryStream(enc.GetBytes(input));
        }
    }
}

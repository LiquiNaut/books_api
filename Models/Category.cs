using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Reference na zoznam kníh v kategórii
        public ICollection<Book>? Books { get; set; }
    }
}
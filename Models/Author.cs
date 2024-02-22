using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nationality { get; set; }
        // Reference na zoznam kníh vydavateľstva
        public ICollection<Book>? Books { get; set; }
    }
}
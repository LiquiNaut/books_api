using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Meno je povinné")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priezvisko je povinné")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Národnosť je povinná")]
        public string Nationality { get; set; } = string.Empty;
        // Reference na zoznam kníh vydavateľstva
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
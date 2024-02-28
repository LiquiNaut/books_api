using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Názov kategórie je povinný")]
        public string Name { get; set; } = string.Empty;

        // Reference na zoznam kníh v kategórii
        public ICollection<Book> Books { get; set; } = [];
    }
}
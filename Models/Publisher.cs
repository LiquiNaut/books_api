using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Názov vydavateľstva je povinný")]
        public string Name { get; set; } = string.Empty;

        // Reference na zoznam kníh vydavateľstva
        public ICollection<Book> Books { get; set; } = [];
    }
}
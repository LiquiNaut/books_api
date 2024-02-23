using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{

    public enum BindingType
    {
        Paperback, Hardcover, Ebook
    }

    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Názov(Titul) je povinný")]
        public string Title { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Neplatné ID autora")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Neplatné číslo ISBN")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Jazyk je povinný")]
        public string Language { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rok vydania je povinný")]
        [Range(1000, 3000, ErrorMessage = "Year of release must be between 1000 and 3000")]
        public int YearOfRelease { get; set; }

        [Required(ErrorMessage = "Počet strán je povinný")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of pages must be a positive number")]
        public int NumberOfPages { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Neplatné ID vydavateľa")]
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Neplatné ID kategórie")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Typ Väzby je povinný")]
        public BindingType Binding { get; set; }

        // Reference na zoznam vypožičaní kníh
        public ICollection<Loan>? Loans { get; set; }
    }
}
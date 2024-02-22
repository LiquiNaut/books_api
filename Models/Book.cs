using System;
using System.Collections.Generic;
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
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Language { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfPages { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public BindingType Binding { get; set; }

        // Reference na zoznam vypožičaní kníh
        public ICollection<Loan>? Loans { get; set; }
    }
}
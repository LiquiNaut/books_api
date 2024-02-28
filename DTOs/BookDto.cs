using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfPages { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public int Binding { get; set; }
    }
}
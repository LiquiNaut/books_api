using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{

    public enum LoanState
    {
        Borrowed, Returned, Returned_with_delay
    }

    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int ReaderId { get; set; }
        public Reader? Reader { get; set; }
        public LoanState State { get; set; }
    }
}
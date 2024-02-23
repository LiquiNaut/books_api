using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "ID knihy je povinné")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required(ErrorMessage = "ID čitateľa je povinné")]
        public int ReaderId { get; set; }
        public Reader? Reader { get; set; }

        [Required(ErrorMessage = "Stav výpožičky je povinný")]
        public LoanState State { get; set; }
    }
}
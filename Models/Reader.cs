using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{

    public enum ReaderType
    {
        Adults, Student, Senior
    }

    public class Reader
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Meno je povinné")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priezvisko je povinné")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mail je povinný")]
        [EmailAddress(ErrorMessage = "Neplatná e-mailová adresa")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefónne číslo je povinné")]
        [Phone(ErrorMessage = "Neplatné telefónne číslo")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vyžaduje sa adresa")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Členské číslo je povinné")]
        public string MemberNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Typ čitateľa je povinný")]
        public ReaderType Type { get; set; }

        // Reference na zoznam vypožičaní čitateľa
        public ICollection<Loan>? Loans { get; set; }
    }
}
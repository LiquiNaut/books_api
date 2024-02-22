using System;
using System.Collections.Generic;
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
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? MemberNumber { get; set; }
        public ReaderType? Type { get; set; }

        // Reference na zoznam vypožičaní čitateľa
        public ICollection<Loan>? Loans { get; set; }
    }
}
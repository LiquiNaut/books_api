using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.UnitOfWorks;

namespace BooksApi.Services
{
    public class BookReturnReminder
    {
        private readonly UnitOfWork _unitOfWork;

        public BookReturnReminder(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SendBookReturnReminders()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);

            // var booksDueTomorrow = _unitOfWork.BookRepository.GetAll()
            //     .Where(b => b.Loans.Any)
        }
    }
}
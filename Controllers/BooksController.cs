using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public BooksController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST /api/books
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        // POST /api/books/borrow
        [HttpPost("borrow")]
        public IActionResult BorrowBook(Loan loan)
        {
            _unitOfWork.LoanRepository.Add(loan);
            _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new { id = loan.BookId }, loan);
        }

        // PUT /api/books/{id}/return
        [HttpPut("{id}/return")]
        public IActionResult ReturnBook(int id)
        {
            var loan = _unitOfWork.LoanRepository.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            loan.State = LoanState.Returned;
            _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
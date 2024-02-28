using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.DTOs;
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
        public IActionResult CreateBook(BookDto bookDto)
        {
            var binding = (BindingType)Enum.Parse(typeof(BindingType), bookDto.Binding.ToString());
            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                ISBN = bookDto.ISBN,
                Language = bookDto.Language,
                YearOfRelease = bookDto.YearOfRelease,
                NumberOfPages = bookDto.NumberOfPages,
                PublisherId = bookDto.PublisherId,
                CategoryId = bookDto.CategoryId,
                Binding = binding
            };

            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {

            var book = _unitOfWork.BookRepository.GetAll()
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    ISBN = b.ISBN,
                    Language = b.Language,
                    YearOfRelease = b.YearOfRelease,
                    NumberOfPages = b.NumberOfPages,
                    PublisherId = b.PublisherId,
                    CategoryId = b.CategoryId,
                    Binding = (int)b.Binding
                })
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookDto.Title;
            book.AuthorId = bookDto.AuthorId;
            book.ISBN = bookDto.ISBN;
            book.Language = bookDto.Language;
            book.YearOfRelease = bookDto.YearOfRelease;
            book.NumberOfPages = bookDto.NumberOfPages;
            book.PublisherId = bookDto.PublisherId;
            book.CategoryId = bookDto.CategoryId;
            book.Binding = (BindingType)bookDto.Binding;

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

            var book = _unitOfWork.BookRepository.GetById(loan.BookId);
            if (book == null)
            {
                return NotFound();
            }

            loan.State = LoanState.Returned;
            _unitOfWork.SaveChanges();

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublisherId = book.PublisherId,
            };

            return Ok(bookDto);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Data;
using BooksApi.Models;
using BooksApi.Repositories;

namespace BooksApi.UnitOfWorks
{
    public class UnitOfWork : IDisposable
    {
        private readonly LibraryContext _context;

        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;
        private CategoryRepository _categoryRepository;
        private PublisherRepository _publisherRepository;
        private LoanRepository _loanRepository;
        private ReaderRepository _readerRepository;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;

            // Inicializácia polí inštanciami repozitárov
            _bookRepository = new BookRepository(_context, this);
            _authorRepository = new AuthorRepository(_context, this);
            _categoryRepository = new CategoryRepository(_context, this);
            _publisherRepository = new PublisherRepository(_context, this);
            _loanRepository = new LoanRepository(_context, this);
            _readerRepository = new ReaderRepository(_context, this);
        }

        public BookRepository BookRepository => _bookRepository;

        public AuthorRepository AuthorRepository => _authorRepository;

        public CategoryRepository CategoryRepository => _categoryRepository;

        public PublisherRepository PublisherRepository => _publisherRepository;

        public LoanRepository LoanRepository => _loanRepository;

        public ReaderRepository ReaderRepository => _readerRepository;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
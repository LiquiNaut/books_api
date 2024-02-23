using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Data;
using BooksApi.Models;
using BooksApi.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Book> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public BookRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Book>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbSet.ToList();
        }

        public Book GetById(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Book entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Book entity)
        {
            _dbSet.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
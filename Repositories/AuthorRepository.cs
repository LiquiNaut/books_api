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
    public class AuthorRepository : IRepository<Author>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Author> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public AuthorRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Author>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbSet.ToList();
        }

        public Author GetById(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Author entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Author entity)
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
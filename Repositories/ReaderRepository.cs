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
    public class ReaderRepository : IRepository<Reader>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Reader> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public ReaderRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Reader>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Reader> GetAll()
        {
            return _dbSet.ToList();
        }

        public Reader GetById(int id)
        {
            return _dbSet.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Reader entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Reader entity)
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
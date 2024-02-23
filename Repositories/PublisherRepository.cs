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
    public class PublisherRepository : IRepository<Publisher>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Publisher> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public PublisherRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Publisher>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _dbSet.ToList();
        }

        public Publisher GetById(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Publisher entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Publisher entity)
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
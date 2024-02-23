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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Category> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public CategoryRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Category>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbSet.ToList();
        }

        public Category GetById(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Category entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Category entity)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LibraryContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(LibraryContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
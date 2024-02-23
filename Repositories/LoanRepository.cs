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
    public class LoanRepository : IRepository<Loan>
    {
        private readonly LibraryContext _context;
        private readonly DbSet<Loan> _dbSet;
        private readonly UnitOfWork _unitOfWork;

        public LoanRepository(LibraryContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<Loan>();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Loan> GetAll()
        {
            return _dbSet.ToList();
        }

        public Loan GetById(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Loan entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Loan entity)
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
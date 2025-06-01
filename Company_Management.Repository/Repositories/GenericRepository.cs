using Company_Management.Core.Models;
using Company_Management.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet= _context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.AnyAsync(expression);
        }

        public void ChangeStatus(T entity)
        {
           _dbSet.Update(entity);
        }

        public Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }

        public IQueryable<T> GetAll()
        {
           return _dbSet.Where(x => x.Status==true).AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}

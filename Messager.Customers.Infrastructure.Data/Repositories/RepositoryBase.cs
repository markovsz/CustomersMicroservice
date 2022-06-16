using Messager.Customers.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity) =>
            await _context.AddAsync(entity);

        public void Delete(T entity) => 
            _context.Remove(entity);

        public IQueryable<T> FinbByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            (trackChanges ? _context.Set<T>().Where(expression) :
                            _context.Set<T>().Where(expression).AsNoTracking());

        public IQueryable<T> FindAll(bool trackChanges) =>
            (trackChanges ? _context.Set<T>() :
                            _context.Set<T>().AsNoTracking());

        public void Update(T entity) =>
            _context.Update(entity);
    }
}

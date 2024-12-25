using Domian.Interfaces;
using Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HotelRusBookingContext RepositoryContext { get; set; }

        public RepositoryBase(HotelRusBookingContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IQueryable<T>> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

        public async Task Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public async Task Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}

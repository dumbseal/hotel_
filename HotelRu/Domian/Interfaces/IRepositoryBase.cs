using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Domian.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindAll(); // Изменено
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression); // Изменено
        Task Create(T entity); // Изменено
        Task Update(T entity); // Изменено
        Task Delete(T entity); // Изменено
    }
}

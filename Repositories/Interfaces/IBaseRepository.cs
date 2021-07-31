using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> where = null);

        Task<T> Find(int id);

        Task<ResultObjectVm> CreateAsync(T entity);

        Task<ResultObjectVm> EditAsync(T entity);
        Task<ResultObjectVm> DeleteAsync(T entity);

        Task<ResultObjectVm> DeleteAsync(int id);
        Task<bool> IsExists(int id);

    }
}

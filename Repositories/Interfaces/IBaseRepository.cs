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

        Task<T> FindById(int id);

        Task<ResultObjectVm> Create(T entity);

        Task<ResultObjectVm> Edit(T entity);


        Task<ResultObjectVm> Delete(int id);
        Task<ResultObjectVm> Delete(T entity);

    }
}

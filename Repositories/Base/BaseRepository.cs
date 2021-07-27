using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> FindById(int id);

        Task<ResultObjectVm> Create(T entity);

        Task<ResultObjectVm> Edit(T entity);


        Task<ResultObjectVm> Delete(int id);

    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public virtual Task<ResultObjectVm> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ResultObjectVm> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ResultObjectVm> Edit(T entity)
        {
            throw new NotImplementedException();

            //db.SaveChanges();
            //return new ResultObject { success = true, message= "با موفقیت ثبت شد."};
        }

        public virtual Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

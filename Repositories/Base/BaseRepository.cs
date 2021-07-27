using BookReader.Data;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Base
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context) {
            _context = context;
        }
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

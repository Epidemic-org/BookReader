using BookReader.Data;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookReader.Repositories.Base
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _dbset;
        
        public BaseRepository(ApplicationDbContext db) {
            _db = db;
            _dbset = _db.Set<T>();
        }
        public virtual async Task<ResultObjectVm> CreateAsync(T entity) {
            try {
                await _dbset.AddAsync(entity);
                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception exp) {
                //TODO: Check For Errros !
                return new ResultObjectVm { Success = false, Message = "خطا در افزودن رخ داد" };
            }
            //TODO: save model to extra ?! for controller 
        }

        public virtual async Task<ResultObjectVm> DeleteAsync(int id) {
            try {
                var entity = await _dbset.FindAsync(id);
                await DeleteAsync(entity);
                return new ResultObjectVm { Success = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception) {
                return new ResultObjectVm { Success = true, Message = "خطا در حذف رخ داد" };
            }
        }

        public virtual async Task<ResultObjectVm> DeleteAsync(T entity) {
            try {
                _dbset.Remove(entity);
                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception) {
                return new ResultObjectVm { Success = true, Message = "خطا در حذف رخ داد" };
            }
        }

        public virtual async Task<ResultObjectVm> EditAsync(T entity) {
            try {
                _dbset.Update(entity);

                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت ویرایش شد" };
            }
            catch (Exception exp) {
                return new ResultObjectVm { Success = true, Message = "خطا در ویرایش رخ داد" };
            }
        }

        public virtual async Task<T> Find(object id) {
            return await _dbset.FindAsync(id);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> where = null) {
            IQueryable<T> query = _dbset;
            if (where != null) {
                query = query.Where(where);
            }
            return query;
        }

        public virtual async Task<bool> IsExists(int id) {
            return await _dbset.FindAsync(id) == null ? false : true;
        }

    }
}

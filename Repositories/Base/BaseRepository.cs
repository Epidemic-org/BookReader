using BookReader.Data;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual async Task<ResultObjectVm> Create(T entity)
        {
            try {
                await _dbset.AddAsync(entity);
                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception) {
                //TODO: Check For Errros !
                return new ResultObjectVm { Success = false, Message = "خطا در افزودن رخ داد" };
            }
        }

        public virtual async Task<ResultObjectVm> Delete(int id)
        {
            try {
                var entity = await _dbset.FindAsync(id);
                await Delete(entity);
                return new ResultObjectVm { Success = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception) {
                return new ResultObjectVm { Success = true, Message = "خطا در حذف رخ داد" };
            }
        }

        public virtual async Task<ResultObjectVm> Delete(T entity) {
            try {
                _dbset.Remove(entity);
                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception) {
                return new ResultObjectVm { Success = true, Message = "خطا در حذف رخ داد" };
            }
        }

        public virtual async Task<ResultObjectVm> Edit(T entity)
        {
            try {
                _dbset.Update(entity);
                await _db.SaveChangesAsync();
                return new ResultObjectVm { Success = true, Message = "با موفقیت ویرایش شد" };
            }
            catch (Exception) {
                return new ResultObjectVm { Success = true, Message = "خطا در ویرایش رخ داد" };
            }
        }

        public virtual async Task<T> FindById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }
    }
}

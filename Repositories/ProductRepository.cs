using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public virtual IQueryable<Product> GetAllBySearch(string search="") {
            return base.GetAll(
                p => p.Title.Contains(search) || p.Description.Contains(search)
                );
        }

        public IQueryable<Product> GetAll(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return base.GetAll();

            return base.GetAll().Where(w => w.Title.Contains(search));
        }


        public IQueryable<Product> GetAll(int userId)
        {
            return base.GetAll().Where(w => w.UserId == userId);
        }

    }
}

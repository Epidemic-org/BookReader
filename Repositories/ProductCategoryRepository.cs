using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductCategoryRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public async Task<ResultObjectVm> CreateAsync(ProductCategoryVm categoryVm)
        {
            // added to db
            return null;
        }
    }
}

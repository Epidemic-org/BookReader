using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class ProductRateRepository : BaseRepository<ProductRate>, IProductRateRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRateRepository(ApplicationDbContext db): base(db) {
            _db = db;
        }


        public async Task<decimal> ProductRateAverage(int productId) {
            return _db.ProductRates.Where(p => p.ProductId == productId).Select(p=> p.RateValue).Average();            
        }


    }
}

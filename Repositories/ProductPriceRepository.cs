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
    public class ProductPriceRepository : BaseRepository<ProductPrice>, IProductPriceRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductPriceRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public IQueryable<ProductPrice> GetAll(string startDate, string endDate) {
            IQueryable<ProductPrice> query = base.GetAll();
            if (query != null) {
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate)) {
                    DateTime validStartDate;
                    DateTime validEndDate;
                    if (DateTime.TryParse(startDate, out validStartDate)) {
                        query = query.Where(p => p.StartDate >= validStartDate);
                        var sc = query.Count();

                    }
                    if (DateTime.TryParse(endDate, out validEndDate)) {
                        query = query.Where(p => p.EndDate <= validEndDate);
                        var ec = query.Count();

                    }
                }
            }
            var a = query.Count();
            return query;
        }

    }
}

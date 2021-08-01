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
            DateTime validStartDate = startDate.ToEnglishDateTime();
            DateTime validEndDate = endDate.ToEnglishDateTime();
            if (query != null) {
                if (validStartDate != default(DateTime)) {
                    query = query.Where(p => p.StartDate >= validStartDate);
                }

                if (validEndDate != default(DateTime)) {
                    query = query.Where(p => p.EndDate <= validEndDate);
                }
            }
            return query;
        }
    }
}

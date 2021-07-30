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
    public class ProductPriceRepository : BaseRepository<ProductPrice>, IProductPrice
    {
        private readonly ApplicationDbContext _db;
        public ProductPriceRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}

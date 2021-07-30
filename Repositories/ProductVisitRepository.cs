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
    public class ProductVisitRepository : BaseRepository<ProductVisit>, IProductVisitRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductVisitRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}

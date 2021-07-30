using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;

namespace BookReader.Repositories
{
    public class CreditTypeRepository : BaseRepository<CreditType>, ICreditTypeRepository
    {

        private readonly ApplicationDbContext _db;
        public CreditTypeRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}

using BookReader.Data;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BookReader.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}

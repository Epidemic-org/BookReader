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
    public class InvoicePaymentRepository : BaseRepository<InvoicePayment>, IInvoicePaymentRepository
    {
        ApplicationDbContext _db;
        public InvoicePaymentRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}

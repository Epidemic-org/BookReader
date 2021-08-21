using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;
        public InvoiceRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        //public IQueryable<vwUserInvoices> GetUserInvoices(int id) {
        //    var query = _db.vwUserInvoices.Where(i => i.Id == id);
        //    return query;
        //}

        public IQueryable<UserInvoicesVM> GetUserInvoices(int id) {
            var query = from invoice in _db.Invoices.Where(i => i.UserId == id)
                        select new UserInvoicesVM() {
                            Id = invoice.Id,
                            Address = invoice.Address,
                            CreationDate = invoice.CreationDate,
                            FirstName = invoice.User.Person.FirstName,
                            LastName = invoice.User.Person.LastName,
                            UserName = invoice.User.UserName,
                            TotalAmount = invoice.TotalAmount
                        };

            return query;
        }

    }
}

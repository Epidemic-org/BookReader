using BookReader.Data.Models;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        IQueryable<UserInvoicesVM> GetUserInvoices(int id);
    }
}

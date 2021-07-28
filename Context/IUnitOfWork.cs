using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookReader.Context
{
    public interface IUnitOfWork 
    {
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public IInvoiceRepository Invoice { get; }
        public IInvoiceItemRepository InvoiceItem { get; }
        public IInvoiceTermRepository InvoiceTerm { get; }
        public ICommentRepository Comments { get; }
    }
}

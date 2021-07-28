using BookReader.Context;
using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace test_book_repository_webapi.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }


        private IProductRepository _productRepository;
        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }
                return _productRepository;
            }
        }


        private IOrderRepository _orderRepository;
        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }
                return _orderRepository;
            }
        }

        private IInvoiceRepository _invoiceRepository;
        public IInvoiceRepository Invoice
        {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(_db);
                }
                return _invoiceRepository;
            }
        }

        private IInvoiceItemRepository _invoiceItemRepository;
        public IInvoiceItemRepository InvoiceItem
        {
            get
            {
                if (_invoiceItemRepository == null)
                {
                    _invoiceItemRepository = new InvoiceItemRepository(_db);
                }
                return _invoiceItemRepository;
            }
        }
        private IInvoiceTermRepository _invoiceTermRepository;
        public IInvoiceTermRepository InvoiceTerm
        {
            get
            {
                if (_invoiceTermRepository == null)
                {
                    _invoiceTermRepository = new InvoiceTermRepository(_db);
                }
                return _invoiceTermRepository;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}



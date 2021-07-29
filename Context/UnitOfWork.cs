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
namespace BookReader.Context
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

       
        private ICommentRepository _commentRepository;
        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_db);
                }
                return _commentRepository;
            }
        }

        private IProductCategoryRepository _productCategories;
        public IProductCategoryRepository ProductCategories
        {
            get
            {
                if(_productCategories == null)
                {
                    _productCategories = new ProductCategoryRepository(_db);
                }
                return _productCategories;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository Users {
            get {
                if (_userRepository == null) {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }


        public void Dispose() {
            _db.Dispose();
        }
    }
}



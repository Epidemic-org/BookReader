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
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
        }


        private IProductRepository _productRepository;
        public IProductRepository Producs { 
            get {
                if(_productRepository == null) {
                    _productRepository = new ProductRepository(_db);
                }
                return _productRepository;
            }
        }


        private IOrderRepository _orderRepository;
        public IOrderRepository Orders {
            get {
                if (_orderRepository == null) {
                    _orderRepository = new OrderRepository(_db);
                }
                return _orderRepository;
            }
        }


        public void Dispose() {
            _db.Dispose();
        }
    }
}



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


        private IBaseRepository<Product> _gnrProductRespository;
        public IBaseRepository<Product> GnrProducts {
            get {
                if (_gnrProductRespository == null) {
                    _gnrProductRespository = new BaseRepository<Product>(_db);
                }
                return _gnrProductRespository;
            }
        }

        private IProductRepository _productRespository;
        public IProductRepository Products {
            get {
                if (_productRespository == null) {
                    _productRespository = new ProductRepository(_db);
                }
                return _productRespository;
            }
        }



        private IBaseRepository<Order> _gnrOrderRespository;
        public IBaseRepository<Order> GnrOrders {
            get {
                if (_gnrOrderRespository == null) {
                    _gnrOrderRespository = new BaseRepository<Order>(_db);
                }
                return _gnrOrderRespository;
            }
        }

        private IOrderRepository _orderRespository;
        public IOrderRepository Orders {
            get {
                if (_orderRespository == null) {
                    _orderRespository = new OrderRepository(_db);
                }
                return _orderRespository;
            }
        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}



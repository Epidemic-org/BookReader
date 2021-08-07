using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.Utillities;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }


        public decimal GetProductPrice(int productId) {
            var product = _db.Products.Find(productId);
            var price = product.ProductPrices.Where(p => p.IsActive == true).First().ProductPriceValue;
            return price;
        }


        public IQueryable<Product> GetAll(string search) {
            if (string.IsNullOrWhiteSpace(search))
                return base.GetAll();

            return base.GetAll().Where(w => w.Title.Contains(search));
        }


        public IQueryable<Product> GetAll(int userId) {
            return base.GetAll().Where(w => w.UserId == userId);
        }


        public IEnumerable<Product> GetFreeProducts(int top) {
            var query = from p in _db.Products.Where(p => p.IsConfirmed == true).ToList()
                        join price in _db.ProductPrices.ToList()
                        on p equals price.Product
                        where price.ProductPriceValue == 0
                        select(p)
                        ;
            return query;
        }
    }
}

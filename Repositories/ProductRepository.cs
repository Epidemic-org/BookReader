using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.EntityFrameworkCore;
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


        public IQueryable<Product> GetAll(string search) {
            if (string.IsNullOrWhiteSpace(search))
                return base.GetAll();
            return base.GetAll().Where(w => w.Title.Contains(search));
        }


        public IQueryable<Product> GetAll(int userId) {
            return base.GetAll().Where(w => w.UserId == userId);
        }


        public IEnumerable<ProductSliderVM> GetFreeProducts() {
            var query = from p in _db.Products.Where(p => p.IsConfirmed == true).ToList()
                        join rate in _db.ProductRates.ToList()
                        on p.Id equals rate.ProductId
                        join price in _db.ProductPrices.ToList()
                        on p.Id equals price.ProductId
                        where price.ProductPriceValue == decimal.Zero
                        select new ProductSliderVM {
                            Id = p.Id,
                            ProductCategoryId = p.ProductCategoryId,
                            CategoryName = "CategoryName",
                            Description = p.Description,
                            Title = p.Title,
                            UserId = p.UserId,
                            UserFullName = "UserName",
                            ProductRateAverage = p.CalProductRateAverage().Average()
                        }                    
                        ;
            return query;
        }


        public decimal getProductPrice(int productId) {
            var product = _db.Products.Find(productId);
            return product.ProductPrices.Where(p => p.IsActive).Single().ProductPriceValue;
        }

    }
}

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
    public class ProductRepository : BaseRepository<Product>, IProductRepository {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IQueryable<Product> GetAll(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return base.GetAll();
            return base.GetAll().Where(w => w.Title.Contains(search));
        }


        public IQueryable<Product> GetAll(int userId)
        {
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
                            CategoryName = p.ProductCategory.Name,
                            Description = p.Description,
                            Title = p.Title,
                            CreationDate = p.CreationDate,
                            EditionDate = p.EditionDate,
                            Price = p.ProductPrices.Where(p => p.IsActive).Select(s=> (double?)s.ProductPriceValue)
                            .FirstOrDefault(),
                            ProductType = p.ProductType,
                            ProductCategoryId = p.ProductCategoryId,
                            UserId = p.UserId,
                            UserFullName = p.User.Person.FirstName + " " + p.User.Person.LastName,
                            Tags = p.Tags,
                            VisitCount = p.ProductVisits.Count(),
                            RateAverage = p.ProductRates.Average(p => (double?)p.RateValue),
                        };
            return query;
        }


        public IQueryable<ProductListVm> GetFreeProducts() {
            var query = GetAllProducts().Where(p => p.Price == 0);
            return query;
        }

        public IQueryable<ProductListVm> GetMostVisitedProducts() {
            var query = GetAllProducts().OrderBy(p => p.VisitCount);
            return query;
        }




        //TODO:By-Dls-> Optimized Method To Extention Methods
        public decimal getProductPrice(int productId) {
            var product = _db.Products.Find(productId);
            return product.ProductPrices.Where(p => p.IsActive).Single().ProductPriceValue;
        }


        public IQueryable<Product> getSortedVisitValue()
        {
            var visitProduct = _db.Products.OrderByDescending(s => s.ProductVisits);
            return visitProduct;
        }
    }
}

using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookReader.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public decimal getProductPrice(int productId) {
            var product = _db.Products.Find(productId);
            return product.ProductPrices.Where(p => p.IsActive).Single().ProductPriceValue;
        }


        public IQueryable<Product> GetAll(string search) {
            if (string.IsNullOrWhiteSpace(search))
                return base.GetAll();
            return base.GetAll().Where(w => w.Title.Contains(search));
        }

        public IQueryable<Product> GetAll(int userId) {
            return base.GetAll().Where(w => w.UserId == userId);
        }


        public IQueryable<ProductListVm> GetAllProducts() {
            var query = from p in _db.Products
                        where p.IsConfirmed
                        select new ProductListVm() {
                            Id = p.Id,
                            CategoryName = p.ProductCategory.Name,
                            Description = p.Description,
                            Title = p.Title,
                            CreationDate = p.CreationDate,
                            EditionDate = p.EditionDate,
                            Price = p.ProductPrices.Where(p => p.IsActive).Select(s => (double?)s.ProductPriceValue)
                            .FirstOrDefault(),
                            ProductType = p.ProductType,
                            ProductCategoryId = p.ProductCategoryId,
                            UserId = p.UserId,
                            UserFullName = p.User.Person.FirstName + " " + p.User.Person.LastName,
                            Tags = p.Tags,
                            SalesCount = p.InvoiceItems.Sum(s => s.Quantity),
                            Pic = p.ProductFiles.Select(f => f.Path).FirstOrDefault(),
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


        public IQueryable<ProductListVm> GetNewestProducts() {
            var query = GetAllProducts().OrderBy(p => p.CreationDate);
            return query;
        }

        public IQueryable<ProductListVm> GetProductsByCategory(int categoryId) {
            var products = GetAllProducts().Where(n => n.ProductCategoryId == categoryId);
            return products;
        }


        public IQueryable<ProductListVm> GetMostSoldProducts() {
            var query = GetAllProducts().OrderByDescending(p => p.SalesCount);
            return query;
        }

        public IQueryable<ProductListVm> GetUserProducts(int userId) {
            var query = from p in GetAllProducts()
                        from invoice in _db.InvoiceItems
                        where p.Id == invoice.ProductId && p.UserId == userId
                        select p;
            return query;
        }
        public IQueryable<ProductListVm> GetUserFavorites(int userId) {
            var query = from p in GetAllProducts()
                        from fav in _db.UserFavorites
                        where p.Id == fav.ProductId && p.UserId == fav.UserId
                        select p;
            return query;
        }
    }
}

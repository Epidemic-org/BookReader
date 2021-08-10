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


        public IQueryable<InvoiceItem>


        public IQueryable<ProductListVm> GetUserProducts(int userId) {
            var query = from invoice in _db.InvoiceItems.Where(i => i.Invoice.InvoicePayments.Count() > 0)
                        where invoice.Invoice.UserId == userId                        
                        select new ProductListVm() {
                            Id = invoice.Product.Id,
                            CategoryName = invoice.Product.ProductCategory.Name,
                            Description = invoice.Product.Description,
                            Title = invoice.Product.Title,
                            CreationDate = invoice.Product.CreationDate,
                            EditionDate = invoice.Product.EditionDate,
                            Price = invoice.Product.ProductPrices.Where(p => p.IsActive).Select(s => (double?)s.ProductPriceValue)
                            .FirstOrDefault(),
                            ProductType = invoice.Product.ProductType,
                            ProductCategoryId = invoice.Product.ProductCategoryId,
                            UserId = invoice.Product.UserId,
                            UserFullName = invoice.Product.User.Person.FirstName + " " + invoice.Product.User.Person.LastName,
                            Tags = invoice.Product.Tags,
                            VisitCount = invoice.Product.ProductVisits.Count(),
                            RateAverage = invoice.Product.ProductRates.Average(p => (double?)p.RateValue),
                        }
                        ;
            return query;
        }
    }
}

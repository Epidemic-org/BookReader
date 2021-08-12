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

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public decimal getProductPrice(int productId)
        {
            var product = _db.Products.Find(productId);
            return product.ProductPrices.Where(p => p.IsActive).Single().ProductPriceValue;
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
        public IQueryable<ProductListVm> GetAllProducts()
        {
            var query = from p in _db.Products
                        where p.IsConfirmed
                        select new ProductListVm()
                        {
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


        public IQueryable<ProductListVm> GetFreeProducts()
        {
            var query = GetAllProducts().Where(p => p.Price == 0);
            return query;
        }


        public IQueryable<ProductListVm> GetMostVisitedProducts()
        {
            var query = GetAllProducts().OrderBy(p => p.VisitCount);
            return query;
        }


        public IQueryable<ProductListVm> GetNewestProducts()
        {
            var query = GetAllProducts().OrderBy(p => p.CreationDate);
            return query;
        }



        public IQueryable<ProductListVm> GetProductsByCategory(int categoryId)
        {
            var products = GetAllProducts().Where(n => n.ProductCategoryId == categoryId);
            return products;
        }


        public class SoldType
        {
            public int ProductId { get; set; }
            public decimal Sum { get; set; }
        }

        public IQueryable<SoldType> MostSoldProducts()
        {
            var query = from invoice in _db.InvoiceItems
                        from product in _db.Products
                        where invoice.Product == product
                        group invoice by product.Id into gp
                        select new SoldType()
                        {
                            ProductId = gp.Key,
                            Sum = gp.Sum(i => i.Quantity)
                        }
                        ;
            return query;
        }
        public IQueryable<ProductListVm> GetMostSoldProducts()
        {
            var query = from t in MostSoldProducts().OrderBy(p => p.Sum)
                        from p in _db.Products
                        where t.ProductId == p.Id
                        select new ProductListVm()
                        {
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
        public IQueryable<ProductListVm> GetUserProducts(int userId)
        {
            var query = _db.InvoiceItems.Where(i => i.Invoice.UserId == userId)
                .Select(i => new ProductListVm()
                {
                    Id = i.ProductId,
                    CategoryName = i.Product.ProductCategory.Name,
                    CreationDate = i.Product.CreationDate,
                    Description = i.Product.Description,
                    EditionDate = i.Product.EditionDate,
                    Price = i.Product.ProductPrices.Where(p => p.IsActive).Select(s => (double?)s.ProductPriceValue)
                            .FirstOrDefault(),
                    ProductType = i.Product.ProductType,
                    Tags = i.Product.Tags,
                    Title = i.Product.Title,
                    UserFullName = i.Product.User.Person.FirstName + " " + i.Product.User.Person.LastName,
                    RateAverage = i.Product.ProductRates.Average(p => (double?)p.RateValue),
                    VisitCount = i.Product.ProductVisits.Count(),
                    ProductCategoryId = i.Product.ProductCategoryId,
                    UserId = i.Product.UserId
                })
                .Distinct()
                ;
            return query;
        }
        public IQueryable<ProductListVm> GetUserFavorites(int userId)
        {
            var favoritesProducts = _db.UserFavorites.Where(n => n.UserId == userId).
                Select(n => new ProductListVm()
                {
                    Id = n.Id,
                    Price = n.Product.ProductPrices.Select(n => (double)n.ProductPriceValue).FirstOrDefault(),
                    Title = n.Product.Title,
                    CategoryName = n.Product.ProductCategory.Name,
                    ProductCategoryId = n.Product.ProductCategoryId,
                    ProductType = n.Product.ProductType,
                    CreationDate = n.CreationDate,
                    Description = n.Product.Description,
                    EditionDate = n.Product.EditionDate,
                    RateAverage = n.Product.ProductRates.Average(p => (double?)p.RateValue),
                    VisitCount = n.Product.ProductVisits.Count(),
                    UserFullName = n.User.Person.FirstName + " " + n.User.Person.LastName,
                    Tags = n.Product.Tags,
                    UserId = n.Product.UserId
                });
            return favoritesProducts;
        }
        public IQueryable<ProductListVm> GetOfflineProducts(int userId)
        {
            var downloadedProducts = _db.ProductDownloads
                .Where(n => n.UserId == userId)
                .Select(n => new ProductListVm
                {
                    CategoryName = n.Product.ProductCategory.Name,
                    CreationDate = n.CreationDate,
                    Description = n.Product.Description,
                    EditionDate = n.Product.EditionDate,
                    Id = n.Id,
                    Price = n.Product.ProductPrices.Select(n => (double?)n.ProductPriceValue).FirstOrDefault(),
                    ProductCategoryId = n.Product.ProductCategoryId,
                    ProductType = n.Product.ProductType,
                    RateAverage = n.Product.ProductRates.Average(n => (double?)n.RateValue),
                    Tags = n.Product.Tags,
                    Title = n.Product.Title,
                    UserFullName = n.User.Person.FirstName + " "+ n.User.Person.LastName,
                    UserId = n.UserId,
                    VisitCount = n.Product.ProductVisits.Count

                });
            return downloadedProducts;
        }
    }
}

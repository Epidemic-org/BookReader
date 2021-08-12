using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookReader.Repositories.ProductRepository;

namespace BookReader.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        decimal getProductPrice(int productId);

        IQueryable<ProductListVm> GetAllProducts();
        IQueryable<ProductListVm> GetMostSoldProducts();
        IQueryable<Product> GetAll(string search);
        IQueryable<Product> GetAll(int userId);
        public IQueryable<ProductListVm> GetUserFavorites(int userId);
        IQueryable<ProductListVm> GetFreeProducts();
        IQueryable<ProductListVm> GetUserProducts(int userId);
        IQueryable<ProductListVm> GetMostVisitedProducts();
        IQueryable<ProductListVm> GetProductsByCategory(int categoryId);
        IQueryable<ProductListVm> GetNewestProducts();
        public IQueryable<ProductListVm> GetOfflineProducts(int userId);

    }
}

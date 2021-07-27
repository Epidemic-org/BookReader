using BookReader.Data.Models;
using BookReader.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {

    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public override IQueryable<Product> GetAll()
        {
            var list = new List<Product>();

            for (int i = 0; i < 50; i++)
            {
                list.Add(new Product
                {
                    Id = i,
                    Title = $"title {i}"
                });
            }

            return list.AsQueryable();
        }
    }
}

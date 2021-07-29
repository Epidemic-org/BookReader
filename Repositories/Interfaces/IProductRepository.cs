using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {

        IQueryable<Product> GetAll(string search);

        IQueryable<Product> GetAll(int userId);
    }
}

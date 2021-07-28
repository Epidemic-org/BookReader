using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookReader.Context
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Product> GnrProducts { get;  }
        public IBaseRepository<Order> GnrOrders { get;  }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public void Dispose();
    }
}

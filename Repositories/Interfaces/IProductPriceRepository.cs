using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface IProductPriceRepository : IBaseRepository<ProductPrice>
    {
        IQueryable<ProductPrice> GetAll(string startDate, string endDate);
    }
}

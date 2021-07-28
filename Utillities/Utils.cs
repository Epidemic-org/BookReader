//TODO:Remove Order model 
using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Utillities
{
    public static class Utils
    {
        public static IQueryable<T> PaginateObjects<T>(this IQueryable<T> q , int page = 1, int pageSize = 10) {
            return q.Skip((page - 1) * pageSize)
             .Take(pageSize);
        }

    }
}

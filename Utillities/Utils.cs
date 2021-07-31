﻿using System.Linq;
using System.Security.Claims;

namespace BookReader.Utillities
{
    public static class Utils
    {
        public static IQueryable<T> PaginateObjects<T>(this IQueryable<T> q , int page = 1, int pageSize = 10) {
            return q.Skip((page - 1) * pageSize)
             .Take(pageSize);
        }
        public static int GetUserId(this ClaimsPrincipal user) {
            var suser = user;
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}

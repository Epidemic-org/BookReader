using BookReader.Data.Models;
using BookReader.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BookReader.Utillities
{
    public static class Utils
    {
        public static IQueryable<T> PaginateObjects<T>(this IQueryable<T> q, int page = 1, int pageSize = 10) {
            return q.Skip((page - 1) * pageSize)
             .Take(pageSize);
        }
        public static int GetUserId(this ClaimsPrincipal user) {
            var suser = user;
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public static decimal TermAmountCalculate(this InvoiceItem invoiceItem) {
            return invoiceItem.Price * invoiceItem.Quantity;
        }

        public static IEnumerable<decimal> CalProductRateAverage(this Product product) {
            return product.ProductRates.Select(p => p.RateValue);
        }

    }
}

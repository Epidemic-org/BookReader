using System.Linq;
using System.Security.Claims;

namespace BookReader.Utillities
{
    public static class Utils
    {
        public static IQueryable<T> PaginateObjects<T>(this IQueryable<T> q , int page = 1, int pageSize = 10) {
            return q.Skip((page - 1) * pageSize)
             .Take(pageSize);
        }

        //TODO: impelement authorized user id getter
        public static int GetUserId(this ClaimsPrincipal user) {
            return int.Parse(user.Claims.First(i => i.Type == "UserId").Value);
        }
    }
}

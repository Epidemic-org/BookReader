using BookReader.Data.Models;
using BookReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<AppUser>
    {
        Task<AppUser> Find(int id);
        Task<AppUser> Find(string id);
        AppUser GetUser(LoginVM userVM);
    }
}

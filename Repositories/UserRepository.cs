using BookReader.Context;
using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class UserRepository : BaseRepository<AppUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
        //TODO:Overload ask
        public  async Task<AppUser> Find(object username) {
            return await _db.Users.SingleOrDefaultAsync(u => u.UserName == (string)username);
        }
    }
}

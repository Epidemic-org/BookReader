using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public async Task<Order> GetAll(int userId) {
            return await base.GetAll(o => o.UserId == userId).FirstOrDefaultAsync();
        }
    }
}

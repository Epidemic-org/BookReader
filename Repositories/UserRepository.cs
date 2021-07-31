
using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using BookReader.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AppUser> Find(string username) {
            return await _db.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

        public AppUser GetUser(LoginVM userVM) {
            return base.GetAll().Where(x => x.UserName.ToLower() == userVM.UserName.ToLower()
                && x.PasswordHash == userVM.Password).FirstOrDefault();
        }
    }
}

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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }


        public async Task<Person> FindbyUserId(int userId) {
            var validPerson = await _db.People.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            return validPerson;
        }


    }
}

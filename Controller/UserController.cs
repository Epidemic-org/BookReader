
using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public UserController(IUnitOfWork db) {
            _db = db;
        }

        /// <summary>
        /// Returns list of users information
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize">Number of users each page contains</param>
        /// <returns>List of type UserListVM</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.AppUsers.GetAll()
                .Select(u => new UserListVM {
                    Id =u.Id,
                    BirthDate =u.Person.BirthDate,
                    CreationDate = u.Person.CreationDate,
                    IsActive = u.IsActive,
                    GenderType = u.Person.GenderType,
                    Name=u.Person.FirstName,
                    LastName = u.Person.LastName,
                    JobType =u.Person.JobType,
                    NationalCode = u.Person.NationalCode,
                    Phone = u.Person.Phone                    
                })
            .ToListAsync();           
            return Ok(list);
        }
        

        /// <summary>
        /// Returns a user with specifid id 
        /// </summary>
        /// <param name="id">Gets user id from url</param>
        /// <returns>AppUser</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] int id) {
            var user = await _db.AppUsers.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            user.IsActive = false;
            user.Person = user.Person;
            var result = await _db.AppUsers.CreateAsync(user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var user = await _db.AppUsers.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            await _db.AppUsers.EditAsync(user);
            return Ok(user);
        }

    }
}

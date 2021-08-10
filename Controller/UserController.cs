
using BookReader.Context;
using BookReader.Data;
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
                    Id = u.Id,
                    BirthDate = u.Person.BirthDate,
                    CreationDate = u.Person.CreationDate,
                    IsActive = u.IsActive,
                    GenderType = u.Person.GenderType,
                    Name = u.Person.FirstName,
                    LastName = u.Person.LastName,
                    JobType = u.Person.JobType,
                    NationalCode = u.Person.NationalCode,
                    Phone = u.Person.Phone
                })
            .PaginateObjects(page, pageSize)
            .ToListAsync();
            return Ok(list);
        }


        /// <summary>
        /// Returns a user with specifid id 
        /// </summary>
        /// <param name="id">Gets user id from url</param>
        /// <returns>AppUser</returns>
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            var user = await _db.AppUsers.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }


        /// <summary>
        /// Insert new user with person 
        /// </summary>
        /// <param name="user">Gets a user as parameter</param>
        /// <returns>ResultObject</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            Person person = new Person();
            user.IsActive = false;
            user.Person = person;
            await _db.People.CreateAsync(person);
            var result = await _db.AppUsers.CreateAsync(user);
            return Ok(result);
        }


        /// <summary>
        /// Returns an editied user
        /// </summary>
        /// <param name="user">Gets a user as parameter</param>
        /// <returns>ResultObject</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            //TODO: USER EDIT FOR ADMINI SIDE ?
            var validUser = await _db.AppUsers.Find(user.Id);
            validUser.IsActive = user.IsActive;

            var result = await _db.AppUsers.EditAsync(user);
            result.Id = user.Id;
            result.Extra = user;
            return Ok(result);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var user = await _db.AppUsers.Find(id);
            if (user == null) {
                return NotFound();
            }
            var result = await _db.AppUsers.DeleteAsync(user);
            result.Id = user.Id;
            result.Extra = user;
            return Ok(result);
        }       

    }
}

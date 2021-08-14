
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

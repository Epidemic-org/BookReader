
using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public UserController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize=10) {       
            var list = await _db.Users.GetAll().PaginateObjects().ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] int id) {
            var user = await _db.Users.Find(id);
            if(user == null) {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.Users.CreateAsync(user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var user = await _db.Users.Find(id);
            if(user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            await _db.Users.EditAsync(user);
            return Ok(user);
        }

    }
}

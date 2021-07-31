using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
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
    
    public class AppRoleController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public AppRoleController(IUnitOfWork db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns list of User Roles
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize">Determine number of roles to each page</param>
        /// <returns>List of type AppRole</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _db.AppRole.GetAll()
                .Select(r => new AppRoleVM() {
                    Id= r.Id,
                    Name = r.Name,
                    RoleType = r.RoleType
                })
                .ToListAsync();

            return Ok(roles);
        }

        /// <summary>
        /// Finds a role by id
        /// </summary>
        /// <param name="id">Gets the id corresponds to role object</param>
        /// <returns>Role</returns>
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            if (!await _db.AppRole.IsExists(id))
            {
                return NotFound();
            }
            var role = await _db.AppRole.Find(id);
            return Ok(role);
        }

        /// <summary>
        /// Inserts new role
        /// </summary>
        /// <param name="role">Gets a role object as parameter to insert</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _db.AppRole.CreateAsync(role);
            result.Id = role.Id;
            result.Extra = role;
            return Ok(result);
        }



        /// <summary>
        /// Edit role object
        /// </summary>
        /// <param name="role">Gets a role object as parameter</param>
        /// <returns>Role</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AppRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _db.AppRole.EditAsync(role);
            result.Id = role.Id;
            result.Extra = role;
            return Ok(result);
        }

        /// <summary>
        /// Deletes a role object
        /// </summary>
        /// <param name="id">Gets the id corresponds to role object</param>
        /// <returns>Role</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var roleToDelete = await _db.AppRole.Find(id);
            if (!await _db.AppRole.IsExists(id))
            {
                return NotFound();
            }
            var result = await _db.AppRole.DeleteAsync(id);
            result.Id = id;
            result.Extra = roleToDelete;
            return Ok(result);
        }
    }
}

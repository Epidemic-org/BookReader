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
    public class UserFavoriteController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public UserFavoriteController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var userFavorites = await _db.UserFavorites.GetAll()
                .Select(u => new UserFavoritesVm
                {
                    CreationDate = u.CreationDate,
                    Id = u.Id,
                    ProductId = u.ProductId,
                    UserId = u.UserId
                })
            .PaginateObjects(page, pageSize)
            .ToListAsync();
            return Ok(userFavorites);
        }
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            var userFavorite = await _db.UserFavorites.Find(id);
            if (userFavorite == null)
            {
                return NotFound();
            }
            return Ok(userFavorite);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserFavorites userFavorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userFavorite.UserId = User.GetUserId();
            var result = await _db.UserFavorites.CreateAsync(userFavorite);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UserFavorites userFavorite)
        {
            var oldUserFavorite = await _db.UserFavorites.Find(userFavorite.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userFavorite.Id = oldUserFavorite.Id;
            userFavorite.CreationDate = oldUserFavorite.CreationDate;
            userFavorite.UserId = oldUserFavorite.UserId;
            var result = await _db.UserFavorites.EditAsync(userFavorite);
            result.Extra = userFavorite;
            result.Id = userFavorite.Id;
            return Ok(result);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userFavorite = await _db.AppUsers.Find(id);
            if (userFavorite == null)
            {
                return NotFound();
            }
            var result = await _db.UserFavorites.DeleteAsync(id);
            result.Id = userFavorite.Id;
            result.Extra = userFavorite;
            return Ok(result);
        }
    }
}

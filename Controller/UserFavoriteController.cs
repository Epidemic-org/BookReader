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
        public UserFavoriteController(IUnitOfWork db) {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserFavoritesVm userFavoriteVm) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            UserFavorites userFavorites = new UserFavorites() {
                CreationDate = DateTime.Now,
                ProductId = userFavoriteVm.ProductId,
                UserId = User.GetUserId()
            };

            var result = await _db.UserFavorites.CreateAsync(userFavorites);

            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var userFavorite = await _db.AppUsers.Find(id);
            if (userFavorite == null) {
                return NotFound();
            }
            var result = await _db.UserFavorites.DeleteAsync(id);
            result.Id = userFavorite.Id;
            result.Extra = userFavorite;
            return Ok(result);
        }
    }
}

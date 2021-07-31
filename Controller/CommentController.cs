using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        public IUnitOfWork _db;
        public CommentController(IUnitOfWork db) {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            //IQueryable<Comment> q = null;
            //q = Utils.PaginateObjects<Comment>(q, page, pageSize);
            //var products = q.ToList();
            //return Ok(products);
            var commentList = await _db.Comments.GetAll().
                Select(s => new CommentVm {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ProductId = s.ProductId,
                    Text = s.Text,        
                    UserId = s.UserId,
                    UserFullName = s.User.Person.FirstName + "" + s.User.Person.LastName
                }
                )
                .PaginateObjects().
                ToListAsync();
            return Ok(commentList);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            if (await _db.Comments.IsExists(id)) {
                var comment = await _db.Comments.Find(id);
                var test = new CommentVm
                {
                    CreationDate = comment.CreationDate,
                    Id = comment.Id,
                    ProductId = comment.ProductId,
                    Text = comment.Text,
                    //UserFullName = comment.User.Person.FirstName + "" + comment.User.Person.LastName
                }
                ;
                return Ok(test);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.Comments.CreateAsync(comment);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Comment comment) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.Comments.EditAsync(comment);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var result = await _db.Comments.DeleteAsync(id);
            return Ok(result);
        }
    }
}

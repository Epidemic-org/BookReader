using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
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
    
    public class CommentLikeController : ControllerBase
    {
        public IUnitOfWork _db;
        public CommentLikeController(IUnitOfWork db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            //IQueryable<Comment> q = null;
            //q = Utils.PaginateObjects<Comment>(q, page, pageSize);
            //var products = q.ToList();
            //return Ok(products);
            var commentList = await _db.CommentLikes.GetAll().
                Select(s => new CommentLikeVm
                {
                    CommentId = s.CommentId,
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    IsLike = s.IsLike,
                    UserId = s.UserId,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName
                }
                )
                .PaginateObjects().
                ToListAsync();
            return Ok(commentList);
        }
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            if (!await _db.CommentLikes.IsExists(id))
            {
                return NotFound();
            }
            var comment = await _db.CommentLikes.Find(id);
            return Ok(comment);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentLike commentLike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            commentLike.CreationDate = DateTime.Now;
            //commentLike.UserId = User.GetUserId();
            commentLike.UserId = 1;
            var result = await _db.CommentLikes.CreateAsync(commentLike);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] CommentLike commentLike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.CommentLikes.EditAsync(commentLike);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.Comments.DeleteAsync(id);
            return Ok(result);
        }
    }
}


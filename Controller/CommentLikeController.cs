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
        public CommentLikeController(IUnitOfWork db) {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            //IQueryable<Comment> q = null;
            //q = Utils.PaginateObjects<Comment>(q, page, pageSize);
            //var products = q.ToList();
            //return Ok(products);
            var commentList = await _db.CommentLikes.GetAll().
                Select(s => new CommentLikeVm {
                    CommentId = s.CommentId,
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    IsLike = s.IsLike,
                    UserId = s.UserId,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName
                }
                )
                .PaginateObjects(page, pageSize).
                ToListAsync();
            return Ok(commentList);
        }
        /// <summary>
        /// Finds a comment like by id
        /// </summary>
        /// <param name="id">the id corresponding to a comment like</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            if (!await _db.CommentLikes.IsExists(id)) {
                return NotFound();
            }
            var comment = await _db.CommentLikes.Find(id);
            return Ok(comment);
        }

        /// <summary>
        /// Create new comment like
        /// </summary>
        /// <param name="commentLike">Gets a comment like object as parameter</param>
        /// <returns>ResultObject</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentLike commentLike) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            commentLike.CreationDate = DateTime.Now;
            commentLike.UserId = User.GetUserId();
            var result = await _db.CommentLikes.CreateAsync(commentLike);
            result.Id = commentLike.Id;
            result.Extra = commentLike;
            return Ok(result);
        }

        /// <summary>
        /// Edit a comment like object 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentLike">Gets a comment like object as parameter</param>
        /// <returns>ResultObject</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CommentLike commentLike) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.CommentLikes.EditAsync(commentLike);
            result.Id = commentLike.Id;
            result.Extra = commentLike;
            return Ok(result);
        }

        /// <summary>
        /// Deletes a comment like object
        /// </summary>
        /// <param name="id">Gets the id correspond to comment like object</param>
        /// <returns>ResultObject</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var commentLikeToDelete = await _db.CommentLikes.Find(id);
            if (commentLikeToDelete == null) {
                return NotFound();
            }
            var result = await _db.CommentLikes.DeleteAsync(commentLikeToDelete);
            result.Id = id;
            result.Extra = commentLikeToDelete;
            return Ok(result);
        }
    }
}


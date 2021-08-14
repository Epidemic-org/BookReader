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
        /// <summary>
        /// Return All Comments of Page "page" which has "pageSize" comments
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>IActionResults of Ok with Comments Model</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int productId, int page = 1, int pageSize = 10) {
            var commentList = await _db.Comments.GetAll().Where(w => w.ProductId == productId).
                Select(s => new CommentVm {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ProductId = s.ProductId,
                    Text = s.Text,
                    UserId = s.UserId,
                    //UserFullName = s.User.Person.FirstName + "" + s.User.Person.LastName
                }
                )
                .PaginateObjects(page, pageSize).
                ToListAsync();
            return Ok(commentList);
        }
        /// <summary>
        /// Find Comment by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Special Comment</returns>
        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            if (await _db.Comments.IsExists(id)) {
                var comment = await _db.Comments.Find(id);
                var test = new CommentVm {
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
        /// <summary>
        /// Add New Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Comment which is ResultObjectVm</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentVmPost commentViewModel, int productId) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }



            Comment comment = new Comment() {

                Text = commentViewModel.Text,
                ProductId = productId,
                UserId = User.GetUserId(),
                IsActive = true,
                //Product = await _db.Products.Find(productId),
                //User = await _db.AppUsers.Find(commentViewModel.UserId),
                CreationDate = DateTime.Now,
                ParentId = commentViewModel.ParentId,
                RateValue = 0,

            };
            var result = await _db.Comments.CreateAsync(comment);
            result.Id = comment.Id;
            result.Extra = comment;
            return Ok(result);
        }
        /// <summary>
        /// Edit a Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns>Return New ResultObjectVm</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Comment comment) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var validComment = await _db.Comments.Find(comment.Id);

            validComment.ProductId = comment.ProductId;
            validComment.UserId = User.GetUserId();
            validComment.Text = comment.Text;
            validComment.CreationDate = comment.CreationDate;
            validComment.IsActive = comment.IsActive;
            validComment.RateValue = comment.RateValue;

            var result = await _db.Comments.EditAsync(validComment);
            result.Id = comment.Id;
            result.Extra = comment;
            return Ok(result);
        }
        /// <summary>
        /// Delete a Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResultViewModel</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var comment = await _db.Comments.Find(id);
            if (comment == null) {
                return NotFound();
            }
            var result = await _db.Comments.DeleteAsync(id);
            result.Id = comment.Id;
            result.Extra = comment;
            return Ok(result);
        }
    }
}

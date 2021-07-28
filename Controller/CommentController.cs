using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookReader.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public IUnitOfWork _db;
        public CommentController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll( int page = 1, int pageSize = 10)
        {
            IQueryable<Comment> q = null;
            q = Utils.PaginateObjects<Comment>(q, page, pageSize);
            var products = q.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            if (!await _db.Comments.IsExists(id)) {
                return NotFound();
            }
            var comment = await _db.Comments.FindById(id);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Comments.CreateAsync(comment);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Comments.EditAsync(comment);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.Comments.DeleteAsync(id);
            return Ok(result);
        }
    }
}

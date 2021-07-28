using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Context;

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search, int page = 1, int pageSize = 10)
        {
            var q = _db.GnrProducts.GetAll();
            if (!string.IsNullOrWhiteSpace(search))
            {
                q = q.Where(w => w.Title.Contains(search) || w.Description.Contains(search));
            }
            var products = q.ToList();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var product = await _db.GnrProducts.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.GnrProducts.Create(product);            
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _db.GnrProducts.Edit(product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.GnrProducts.Delete(id);
            return Ok(result);
        }
    }
}

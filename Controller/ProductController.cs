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
using BookReader.Utillities;

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
            var q = _db.Products.GetAll();
            if (!string.IsNullOrWhiteSpace(search))
            {
                q = q.Where(w => w.Title.Contains(search) || w.Description.Contains(search));
            }
            q = Utils.PaginateObjects<Order>(q, page, pageSize);
            var products = q.ToList();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var product = await _db.Products.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Products.Create(product);            
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _db.Products.Edit(product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.Products.Delete(id);
            return Ok(result);
        }
    }
}

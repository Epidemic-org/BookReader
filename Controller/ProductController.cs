using BookReader.Data.Models;
using BookReader.Repositories;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search, int page = 1, int pageSize = 10)
        {
            var q = _productRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
            {
                q = q.Where(w => w.Title.Contains(search) || w.Description.Contains(search));
            }
            var products = q.ToList();
            //var products = await q.Skip((page - 1) * pageSize)
            // .Take(pageSize).OrderByDescending(o => o.CreationDate)
            // .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var product = await _productRepository.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productRepository.Create(product);
            
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productRepository.Edit(product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
    }
}

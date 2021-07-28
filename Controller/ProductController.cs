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
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public ProductController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetAll(string search, int page = 1, int pageSize = 10) {
            //var q = _db.Products.GetAllBySearch(search);
            //q = Utils.PaginateObjects<Product>(q, page, pageSize);
            //var products = q.ToList();


            var list = await _db.Products.GetAll(search)
                .Select(s=> new ProductListVm
                {
                    CreationDate = s.CreationDate,
                    Description = s.Description,
                    EditionDate = s.EditionDate,
                    Id = s.Id,
                    ProductCategoryId = s.ProductCategoryId,
                    CategoryName = s.ProductCategory.Name,
                    ProductType = s.ProductType,
                    Tags = s.Tags,
                    Title = s.Title,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName,
                    UserId = s.UserId,
                })
                .PaginateObjects(page, pageSize).ToListAsync();
            
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            if (await _db.Products.IsExists(id)) {

                var product = await _db.Products.FindById(id);
                return Ok(product);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //product.UserId = User.GetUserId();
            product.UserId = 1;
            product.AdminId = 1;
            product.CreationDate = DateTime.Now;
            product.IsConfirmed = false;

            var result = await _db.Products.CreateAsync(product);
            result.Id = product.Id;
            result.Extra = product;
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create2([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Products.CreateAsync(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var old = await _db.Products.FindById(product.Id);

            old.ProductCategoryId = product.Id;
            old.Title = product.Title;
            old.Description = product.Description;


            var result = await _db.Products.EditAsync(old);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var result = await _db.Products.DeleteAsync(id);
            return Ok(result);
        }
    }
}

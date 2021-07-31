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

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public ProductCategoryController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            //var list = await _db.ProductCategories.GetAll().ToListAsync();
            var PrdouctCategoryList = await _db.ProductCategories.GetAll().Select(
                s => new ProductCategoryVm
                {
                    Id = s.Id,
                    ParentId = s.ParentId,
                    DisplayOrder = s.DisplayOrder ,
                    Pic =s.Pic ,
                    Icon = s.Icon,
                    IsActive = s.IsActive,
                    CreationDate = s.CreationDate,
                    ProductType = s.ProductType
                }).ToListAsync();




            return Ok(PrdouctCategoryList);
        }

     

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCategory productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            productCategory.AdminId = User.GetUserId();
            productCategory.CreationDate = DateTime.Now;
            productCategory.IsActive = false;


            var result = await _db.ProductCategories.CreateAsync(productCategory);
            result.Id = productCategory.Id;
            result.Extra = productCategory;
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var old = await _db.ProductCategories.Find(productCategory.Id);
            
            return Ok();
        }
     
    }
}

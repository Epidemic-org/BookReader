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
            //var q = _db.ProductCategorys.GetAllBySearch(search);
            //q = Utils.PaginateObjects<ProductCategory>(q, page, pageSize);
            //var ProductCategorys = q.ToList();


            var list = await _db.ProductCategories.GetAll().ToListAsync();
            
            return Ok(list);
        }

     

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCategoryVm categoryVm) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.ProductCategories.CreateAsync(categoryVm);
            return Ok(result);
        }

       
    }
}

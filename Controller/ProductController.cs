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
using System.Security.Claims;

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public ProductController(IUnitOfWork db) {
            _db = db;
        }

        /// <summary>
        /// Returns list of products
        /// </summary>
        /// <param name="search">Filters products which Title and Descriptions contains search text</param>
        /// <param name="page">Set number of pages to paginate</param>
        /// <param name="pageSize">Set products count to display on each page</param>
        /// <returns>List Of Products></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(string search, int page = 1, int pageSize = 10) {
            var list = await _db.Products.GetAll()
                .Select(p => new ProductListVm {
                    Id = p.Id,
                    ProductCategoryId = p.ProductCategoryId,
                    CategoryName = p.ProductCategory.Name,
                    Title = p.Title,
                    Description = p.Description,
                    Tags = p.Tags,
                    UserId = p.UserId,
                    UserFullName = p.User.Person.FirstName + " " + p.User.Person.LastName,
                    CreationDate = p.CreationDate,
                    EditionDate = p.EditionDate,
                    ProductType = p.ProductType
                })
                .PaginateObjects()
                .ToListAsync();
            return Ok(list);
        }

        /// <summary>
        /// Returns a specified product by id
        /// </summary>
        /// <param name="id">Gets id of product to find from url</param>
        /// <returns>Product</returns>
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            if (await _db.Products.IsExists(id)) {
                var product = await _db.Products.Find(id);
                //TODO: get then fill VM ?
                //ProductListVm productListVm = new ProductListVm();
                //productListVm.Id = product.Id;
                //productListVm.ProductCategoryId = product.ProductCategoryId;
                //productListVm.CategoryName = product.ProductCategory.Name;
                //productListVm.Title = product.Title;
                //productListVm.Description = product.Description;
                //productListVm.Tags = product.Tags;
                //productListVm.UserId = product.UserId;
                //productListVm.UserFullName = product.User.Person.FirstName + " " + product.User.Person.LastName;
                //productListVm.CreationDate = product.CreationDate;
                //productListVm.EditionDate = product.EditionDate;
                //productListVm.ProductType = product.ProductType;
                return Ok(product);
            }
            else {
                return NotFound();
            }
        }

        /// <summary>
        /// Insert new product
        /// </summary>
        /// <param name="product">Product entitiy gets from body</param>
        /// <returns>ResultObject</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            product.UserId = User.GetUserId();
            product.AdminId = 1;
            product.CreationDate = DateTime.Now;
            product.IsConfirmed = false;
            var result = await _db.Products.CreateAsync(product);
            result.Id = product.Id;
            result.Extra = product;
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create2([FromBody] Product product) {
        //    if (!ModelState.IsValid) {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _db.Products.CreateAsync(product);
        //    return Ok(result);
        //}

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="product">Product to delete which gets from body</param>
        /// <returns>ResultObject</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.Products.EditAsync(product);
            result.Id = product.Id;
            result.Extra = product;
            return Ok(result);
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResultObject</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var productToDelete = await _db.Products.Find(id);
            if(productToDelete == null) {
                return NotFound();
            }
            var result = await _db.Products.DeleteAsync(productToDelete);
            result.Id = id;
            result.Extra = productToDelete;
            return Ok(result);
        }
    }
}

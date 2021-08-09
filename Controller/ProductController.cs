using BookReader.Context;
using BookReader.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll(string search = "", int? categoryId = null, int page = 1, int pageSize = 10) {

            var q = _db.Products.GetAll();

            if (!string.IsNullOrWhiteSpace(search)) {
                q = q.Where(w => w.Title.Contains(search) || w.Description.Contains(search));
            }

            var list = await q
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
                .PaginateObjects(page, pageSize)
                .ToListAsync();
            return Ok(list);
        }


        /// <summary>
        /// Returns list of free products
        /// </summary>
        /// <param name="top">Number of products should return</param>
        /// <returns>List of type products</returns>
        [HttpGet]
        public async Task<IActionResult> GetFreeProducts([FromRoute] int top) {
            var products = await _db.Products.GetFreeProducts()
                 .PaginateObjects(1, 10)
                 .ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetMostSoldProducts([FromRoute] int top) {
            var products = await _db.Products.GetMostVisitedProducts()
                .Take(top)
                .ToListAsync();
            return Ok(products);
        }



        /// <summary>
        /// Get the newest product 
        /// </summary>
        /// <param name="numberOfProducts"></param>
        /// <returns>The List Of Products</returns>
        //[HttpGet]
        public async Task<IActionResult> GetNewestPropducts(int top)
        { 
            var products = await _db.Products.GetNewestProducts()
                .PaginateObjects(1, 10)
                .ToListAsync();
            return Ok(products);
        }

        /// <summary>
        /// Returns a specified product by id
        /// </summary>
        /// <param name="id">Gets id of product to find from url</param>
        /// <returns>Product</returns>
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            if (!await _db.Products.IsExists(id)) {
                return NotFound();

            }
            var product = await _db.Products.Find(id);
            return Ok(product);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var productToDelete = await _db.Products.Find(id);
            if (productToDelete == null) {
                return NotFound();
            }
            var result = await _db.Products.DeleteAsync(productToDelete);
            result.Id = id;
            result.Extra = productToDelete;
            return Ok(result);
        }
    }
}

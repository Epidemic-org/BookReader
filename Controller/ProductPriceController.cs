using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
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
    public class ProductPriceController : ControllerBase {
        private readonly IUnitOfWork _db;
        public ProductPriceController(IUnitOfWork db) {
            _db = db;
        }

        /// <summary>
        /// Returns list of product prices
        /// </summary>
        /// <param name="startDate">string start datetime when price has been set</param>
        /// <param name="endDate">string end datetime when price will expire</param>
        /// <returns>List of type product price</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(string startDate, string endDate) {
            var prices = await _db.ProductPrices.GetAll(startDate, endDate)
                .Select(p => new ProductPriceVm() {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    ProductPriceValue = p.ProductPriceValue,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    CreationDate = p.CreationDate
                })
                .ToListAsync();
            return Ok(prices);
        }


        /// <summary>
        /// Returns a product price by id
        /// </summary>
        /// <param name="id">Gtes the id corresponds to product price object</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            var price = await _db.ProductPrices.Find(id);
            if (price == null) {
                return NotFound();
            }
            return Ok(price);
        }

        /// <summary>
        /// Inserts new product price object
        /// </summary>
        /// <param name="productPrice">Gets a product price object as parameter</param>
        /// <returns>Product Price</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductPrice productPrice) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            productPrice.AdminId = User.GetUserId();
            productPrice.CreationDate = DateTime.Now;
            var result = await _db.ProductPrices.CreateAsync(productPrice);
            result.Id = productPrice.Id;
            result.Extra = productPrice;
            return Ok(result);
        }


        /// <summary>
        /// Edits the product price
        /// </summary>
        /// <param name="productPrice">Gets the product price object as parameter</param>
        /// <returns>Product Price</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProductPrice productPrice) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.ProductPrices.EditAsync(productPrice);
            result.Id = productPrice.Id;
            result.Extra = productPrice;
            return Ok(result);
        }
    }
}

using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrderController(IUnitOfWork db) {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> FindById() {
            var validOrder = await _db.Orders.GetAll(o => o.UserId == User.GetUserId()).FirstOrDefaultAsync();
            if (validOrder == null) {
                return NotFound();
            }
            var order = new OrderVm() {
                Id = validOrder.Id,
                UserId = validOrder.UserId,
                Address = validOrder.Address,
                CreationDate = validOrder.CreationDate,
                UserFullName = validOrder.User.Person.FirstName + " " + validOrder.User.Person.LastName,
                TotalAmount = validOrder.OrderItems.Sum(
                    o => o.Product.ProductPrices.Where(p => p.IsActive).FirstOrDefault().ProductPriceValue *
                    o.Quantity
                    )
            };
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] OrderVm order) {
            var validOrder = await _db.Orders.Find(order.Id);
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            validOrder.Id = order.Id;
            validOrder.UserId = order.UserId;
            validOrder.CreationDate = order.CreationDate;
            validOrder.Address = order.Address;

            var result = await _db.Orders.EditAsync(validOrder);
            result.Id = order.Id;
            result.Extra = order;
            return Ok(result);
        }

    }
}

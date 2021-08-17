using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrderItemController(IUnitOfWork db) {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var orderItems = _db.OrderItems.GetAll(o => o.Order.UserId == User.GetUserId())
                .Select(o => new OrderItemGetVM() {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    Title = o.Product.Title,
                    Description = o.Product.Description,
                    Pic = o.Product.ProductFiles.Select(f => f.Path).FirstOrDefault(),
                    Price = o.Product.ProductPrices
                    .Where(p => p.IsActive).Select(s => s.ProductPriceValue).FirstOrDefault(),
                    RateValue = o.Product.ProductRates.Average(p => p.RateValue),
                    UserFullName = o.Order.User.Person.FirstName + " " + o.Order.User.Person.LastName
                });
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderItemVm orderItem) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var validOrder = new Order();

            validOrder = await _db.Orders.GetAll(User.GetUserId());

            if (validOrder == null) {
                validOrder = new Order() {
                    CreationDate = DateTime.Now,
                    Address = "",
                    UserId = User.GetUserId()
                };
                await _db.Orders.CreateAsync(validOrder);
            }

            var validOrderItem = new OrderItem() {
                OrderId = validOrder.Id,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };

            var result = await _db.OrderItems.CreateAsync(validOrderItem);
            result.Id = validOrderItem.Id;
            result.Extra = validOrder;
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var validOrderItem = await _db.OrderItems.Find(id);

            if (validOrderItem == null) {
                return NotFound();
            }

            var result = await _db.OrderItems.DeleteAsync(id);
            if (result.Success) {
                var validOrder = await _db.Orders.GetAll(User.GetUserId());
                if (validOrder.OrderItems.Count() == 0) {
                    await _db.Orders.DeleteAsync(validOrder);
                }
            }

            result.Id = id;
            result.Extra = validOrderItem;
            return Ok(validOrderItem);
        }
    }
}

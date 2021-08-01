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
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public OrderController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.Orders.GetAll().
                Select(s => new OrderVm
                {
                    Address = s.Address,
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    UserId = s.UserId,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName
                }
                )
                .PaginateObjects().ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            if (!await _db.Orders.IsExists(id))
            {
                return NotFound();
            }
            var order = await _db.Orders.Find(id);
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            order.CreationDate = DateTime.Now;
            order.UserId = User.GetUserId();
            var result = await _db.Orders.CreateAsync(order);
            result.Extra = order;
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Order order)
        {
            var oldOrder = await _db.Orders.Find(order.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            order.CreationDate = oldOrder.CreationDate;
            order.Address = oldOrder.Address;
            order.OrderItems = oldOrder.OrderItems;
            order.UserId = User.GetUserId();
            var result = await _db.Orders.EditAsync(order);
            result.Id = order.Id;
            result.Extra = order;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            if (!await _db.Orders.IsExists(id))
            {
                return NotFound();
            }
            var result = await _db.Orders.DeleteAsync(id);
            return Ok(result);
        }
    }
}

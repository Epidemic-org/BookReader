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
    public class OrderController : ControllerBase {
        private readonly IUnitOfWork _db;
        public OrderController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.Orders.GetAll().Select(s=>new OrderVm
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Address = s.Address,
                UserId = s.UserId
            }).PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            if (!await _db.Orders.IsExists(id))return NotFound();
            var order = await _db.Orders.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.Orders.CreateAsync(order);
            result.Id = order.Id;
            result.Extra = order;
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> PutOrder([FromBody] Order order) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.Orders.EditAsync(order);
            result.Id = order.Id;
            result.Extra = order;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id) {
            var order = await _db.Orders.Find(id);
            if (order == null) return NotFound();
            var result = await _db.Orders.DeleteAsync(id);
            result.Id = id;
            result.Extra = order;
            return Ok(result);
        }
    }
}

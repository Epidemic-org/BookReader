using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
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
    public class OrderController : ControllerBase {
        private readonly IUnitOfWork _db;
        public OrderController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            //var list = await _db.Orders.GetAll().PaginateObjects().ToListAsync();
            //return Ok(list);
            //TODO:PROMLEM WITH PAGINATION EX METHOD.
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            if (!await _db.Orders.IsExists(id)) {
                return NotFound();
            }
            var order = await _db.Orders.Find(id);
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.Orders.CreateAsync(order);
            result.Extra = order;
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> PutOrder([FromBody] Order order) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var result = await _db.Orders.EditAsync(order);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id) {
            if(!await _db.Orders.IsExists(id)) {
                return NotFound();
            }
            var result = await _db.Orders.DeleteAsync(id);
            return Ok(result);
        }
    }
}

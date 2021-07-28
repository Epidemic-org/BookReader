using BookReader.Context;
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
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public OrderController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(string search = "", int page = 1, int pageSize = 10) {
            var q = _db.Orders.GetAll();
            if (!string.IsNullOrEmpty(search)) {

            }

            return Ok(orders);
        }

    }
}

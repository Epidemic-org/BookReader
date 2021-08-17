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
    public class InvoiceItemController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceItemController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.InvoiceItem.GetAll().
                Select(s => new InvoiceItemVm {
                    Id = s.Id,
                    InvoiceID = s.InvoiceID,
                    Price = s.Price,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    TermAMount = s.TermAMount
                })
                .
                PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }
    }
}

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
        public InvoiceItemController(IUnitOfWork db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.InvoiceItem.GetAll().
                Select(s => new InvoiceItemVm
                {
                    Id = s.Id,
                    InvoiceID = s.InvoiceID,
                    Price = s.Price,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    TermAMount = s.TermAMount
                }
                ).
                PaginateObjects(page,pageSize).ToListAsync();
            return Ok(list);
        }       

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            if (!await _db.InvoiceItem.IsExists(id))
            {
                return NotFound();
            }
            var invoiceItem = await _db.InvoiceItem.Find(id);
            return Ok(invoiceItem);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceItem invoiceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            invoiceItem.Price = _db.Products.getProductPrice(invoiceItem.ProductId);
            invoiceItem.TermAMount = invoiceItem.TermAmountCalculate();
            await _db.InvoiceItem.CreateAsync(invoiceItem);
            return Ok(invoiceItem);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] InvoiceItem invoiceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _db.InvoiceItem.EditAsync(invoiceItem);
            result.Id = invoiceItem.Id;
            result.Extra = invoiceItem;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var invoiceItem = _db.InvoiceItem.Find(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            var result = await _db.InvoiceItem.DeleteAsync(id);
            result.Id = id;
            result.Extra = invoiceItem;
            return Ok(result);
        }
    }
}

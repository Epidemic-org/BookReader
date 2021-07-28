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
    public class InvoiceItemController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceItemController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 10)
        {
            var q = _db.InvoiceItem.GetAll();
            q = Utils.PaginateObjects<InvoiceItem>(q);
            return Ok(q.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            if (!await _db.InvoiceItem.IsExists(id))
            {
                return NotFound();
            }
            var invoiceItem = await _db.InvoiceItem.FindById(id);
            return Ok(invoiceItem);
        }


        [HttpPost]
        public async Task<IActionResult> PostInvoiceItem([FromBody] InvoiceItem invoiceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _db.InvoiceItem.Create(invoiceItem);
            return Ok(invoiceItem);
        }


        [HttpPut]
        public async Task<IActionResult> PutInvoiceItem([FromBody] InvoiceItem invoiceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _db.InvoiceItem.Edit(invoiceItem);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoiceItem([FromRoute] int id)
        {
            if (!await _db.InvoiceItem.IsExists(id))
            {
                return NotFound();
            }
            var result = await _db.InvoiceItem.Delete(id);
            return Ok(result);
        }
    }
}

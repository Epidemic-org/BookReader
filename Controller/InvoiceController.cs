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


    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 10)
        {
            var q = _db.Invoice.GetAll();
            q = Utils.PaginateObjects<Invoice>(q);
            return Ok(q.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            if (await _db.Invoice.IsExists(id))
            {

                var Invoice = await _db.Invoice.FindById(id);
                return Ok(Invoice);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Invoice.Create(invoice);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditInvoice([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Invoice.Edit(invoice);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _db.Invoice.Delete(id);
            return Ok(result);
        }
    }
}




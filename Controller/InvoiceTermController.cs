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
    public class InvoiceTermController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceTermController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var q = _db.InvoiceTerm.GetAll();
            q = Utils.PaginateObjects<InvoiceTerm>(q);
            return Ok(q.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            if (await _db.InvoiceTerm.IsExists(id))
            {

                var invoiceTerm = await _db.InvoiceTerm.FindById(id);
                return Ok(invoiceTerm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceTerm([FromBody] InvoiceTerm invoiceTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.InvoiceTerm.Create(invoiceTerm);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditInvoiceTerm([FromBody] InvoiceTerm invoiceTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.InvoiceTerm.Edit(invoiceTerm);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoiceTerm(int id)
        {
            var result = await _db.InvoiceTerm.Delete(id);
            return Ok(result);
        }
    }
}

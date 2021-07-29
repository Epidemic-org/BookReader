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


    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.Invoice.GetAll().
                Select(s => new InvoiceVm
                {
                    Address = s.Address,
                    PayableAmount = s.PayableAmount,
                    CreationDate = s.CreationDate,
                    TotalAmount = s.TotalAmount,
                    TotalTerms = s.TotalTerms,
                    UserId = s.UserId,
                    Id = s.Id,
                    PermitGenerationId = s.PermitGenerationId,
                    
                }
                ).
                PaginateObjects().ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var invoice = await _db.Invoice.FindById(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);

            //if (await _db.Invoice.IsExists(id))
            //{
            //    var Invoice = await _db.Invoice.FindById(id);
            //    return Ok(Invoice);
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Invoice.CreateAsync(invoice);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _db.Invoice.EditAsync(invoice);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _db.Invoice.DeleteAsync(id);
            return Ok(result);
        }
    }
}




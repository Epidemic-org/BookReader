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
    public class InvoiceTermController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoiceTermController(IUnitOfWork db)
        {
            _db = db;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        //{
        //    var list = await _db.InvoiceTerm.GetAll().
        //        Select(s => new InvoiceTermVm
        //        {
        //            Id = s.Id,
        //            InvoiceId = s.InvoiceId,
        //            TermAmount = s.TermAmount,
        //            TermTypeId = s.TermTypeId

        //        }
        //        ).
        //        PaginateObjects(page, pageSize).ToListAsync();
        //    return Ok(list);

        //}

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            if (await _db.InvoiceTerm.IsExists(id))
            {

                var invoiceTerm = await _db.InvoiceTerm.Find(id);
                return Ok(invoiceTerm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? invoiceId = null, int page = 1, int pageSize = 10)
        {
            var invoiceTermList = _db.InvoiceTerm.GetAll();
            if (invoiceId != null)
            {
                invoiceTermList = invoiceTermList.Where(n => n.InvoiceId == invoiceId);
            }
            var list = await invoiceTermList
                .Select(s => new InvoiceTerm()
                {
                    Id = s.Id,
                    InvoiceId = s.InvoiceId,
                    TermAmount = s.TermAmount,
                    TermTypeId = s.TermTypeId

                })
                .PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceTermVm invoiceTermVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InvoiceTerm invoiceTerm = new InvoiceTerm()
            {
                Id = invoiceTermVm.Id,
                InvoiceId = invoiceTermVm.InvoiceId,
                TermAmount = invoiceTermVm.TermAmount,
                TermTypeId = invoiceTermVm.TermTypeId,
            };

            var result = await _db.InvoiceTerm.CreateAsync(invoiceTerm);
            result.Id = invoiceTermVm.Id;
            result.Extra = invoiceTermVm;
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] InvoiceTermVm invoiceTermVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var oldInvoiceTerm = await _db.InvoiceTerm.Find(invoiceTermVm.Id);
            oldInvoiceTerm.Id = invoiceTermVm.Id;
            oldInvoiceTerm.InvoiceId = invoiceTermVm.InvoiceId;
            oldInvoiceTerm.TermAmount = invoiceTermVm.TermAmount;
            oldInvoiceTerm.TermTypeId = invoiceTermVm.TermTypeId;

            var result = await _db.InvoiceTerm.EditAsync(oldInvoiceTerm);
            result.Id = invoiceTermVm.Id;
            result.Extra = invoiceTermVm;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceTerm = await _db.InvoiceTerm.Find(id);
            if (invoiceTerm == null)
            {
                return NotFound();
            }
            var result = await _db.InvoiceTerm.DeleteAsync(id);
            result.Id = invoiceTerm.Id;
            result.Extra = invoiceTerm;
            return Ok(result);
        }
    }
}

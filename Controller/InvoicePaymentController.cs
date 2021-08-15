using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class InvoicePaymentController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public InvoicePaymentController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.InvoicePayments.GetAll().
                Select(s => new InvoicePaymentVm
                {
                    Id = s.Id,
                    InvoiceId = s.Invoice.Id,
                    CreationDate = s.CreationDate,
                    PayAmount = s.PayAmount,
                    TransactionId = s.TransactionId

                }
                ).
                PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int invoiceId, int page = 1, int pageSize = 10)
        {
            var invoiceList = await _db.InvoicePayments.GetAll()
                .Where(n => n.InvoiceId == invoiceId)
                .Select(s => new InvoicePaymentVm
                {
                    Id = s.Id,
                    InvoiceId = s.Invoice.Id,
                    CreationDate = s.CreationDate,
                    PayAmount = s.PayAmount,
                    TransactionId = s.TransactionId

                })
                .PaginateObjects(page, pageSize)
                .ToListAsync();
            return Ok(invoiceList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoicePaymentVm invoicePaymentVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InvoicePayment invoicePayment = new InvoicePayment()
            {
                CreationDate = DateTime.Now,
                Id = invoicePaymentVm.Id,
                TransactionId = invoicePaymentVm.TransactionId,
                InvoiceId = invoicePaymentVm.InvoiceId,
                PayAmount = invoicePaymentVm.PayAmount,

            };

            var result = await _db.InvoicePayments.CreateAsync(invoicePayment);

            result.Id = invoicePaymentVm.Id;
            result.Extra = invoicePaymentVm;

            return Ok(result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Edit([FromBody] InvoicePaymentVm invoicePaymentVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var oldInvoicePayment = await _db.InvoicePayments.Find(invoicePaymentVm.Id);
        //    oldInvoicePayment.Id = invoicePaymentVm.Id;
        //    oldInvoicePayment.InvoiceId = invoicePaymentVm.InvoiceId;
        //    oldInvoicePayment.PayAmount = invoicePaymentVm.PayAmount;
        //    oldInvoicePayment.TransactionId = invoicePaymentVm.TransactionId;

        //    var result = await _db.InvoicePayments.EditAsync(oldInvoicePayment);
        //    result.Id = invoicePaymentVm.Id;
        //    result.Extra = invoicePaymentVm;
        //    return Ok(result);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var invoicePament = _db.InvoicePayments.Find(id);
        //    if (invoicePament == null)
        //    {
        //        return NotFound();
        //    }
        //    var result = await _db.InvoicePayments.DeleteAsync(id);
        //    result.Id = id;
        //    result.Extra = invoicePament;
        //    return Ok(result);
        //}
    }
}

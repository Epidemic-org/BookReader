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
        public InvoicePaymentController(IUnitOfWork db) {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.InvoicePayments.GetAll().
                Select(s => new InvoicePaymentVm {
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
        public async Task<IActionResult> FindById(int id) {
            var invoicePayment = await _db.InvoicePayments.Find(id);
            if (invoicePayment == null) {
                return NotFound();
            }

            InvoicePaymentVm invoicePaymentVM = new InvoicePaymentVm() {
                Id = invoicePayment.Id,
                CreationDate = invoicePayment.CreationDate,
                InvoiceId = invoicePayment.InvoiceId,
                PayAmount = invoicePayment.PayAmount,
                TransactionId = invoicePayment.TransactionId                
            };

            return Ok(invoicePaymentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoicePaymentVm invoicePaymentVm) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            InvoicePayment invoicePayment = new InvoicePayment() {
                CreationDate = DateTime.Now,
                Id = invoicePaymentVm.Id,
                TransactionId = invoicePaymentVm.TransactionId,
                InvoiceId = invoicePaymentVm.InvoiceId,
                PayAmount = invoicePaymentVm.PayAmount
            };

            var result = await _db.InvoicePayments.CreateAsync(invoicePayment);
            result.Id = invoicePayment.Id;
            result.Extra = invoicePayment;
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] InvoicePayment invoicePayment) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _db.InvoicePayments.EditAsync(invoicePayment);
            result.Id = invoicePayment.Id;
            result.Extra = invoicePayment;
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var invoicePament = _db.InvoicePayments.Find(id);
            if (invoicePament == null) {
                return NotFound();
            }
            var result = await _db.InvoicePayments.DeleteAsync(id);
            result.Id = id;
            result.Extra = invoicePament;
            return Ok(result);
        }
    }
}

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
        public InvoiceController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.Invoice.GetAll().
                Select(s => new InvoiceVm {
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
                PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id) {
            var invoice = await _db.Invoice.Find(id);
            if (invoice == null) {
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
        public async Task<IActionResult> Create([FromRoute] int orderId) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var validOrder = await _db.Orders.Find(orderId);

            var validInvoice = new Invoice() {
                UserId = validOrder.UserId,
                PermitGenerationId = 1,
                Address = validOrder.Address,
                CreationDate = DateTime.Now,
                TotalAmount = validOrder.OrderItems.Sum(
                    o => o.Product.ProductPrices.Where(p => p.IsActive).FirstOrDefault().ProductPriceValue *
                    o.Quantity
                    ),
                TotalTerms = 0,                
            };

            validInvoice.PayableAmount = validInvoice.TotalAmount - validInvoice.TotalTerms;
            var result = await _db.Invoice.CreateAsync(validInvoice);

            foreach (var item in validOrder.OrderItems) {
                var invoiceItem = new InvoiceItem() {
                    InvoiceID = validInvoice.Id,
                    Price = item.Product.ProductPrices.Where(p => p.IsActive)
                    .FirstOrDefault().ProductPriceValue,
                    Quantity = item.Quantity,
                    TermAMount = 0,
                    ProductId = item.ProductId
                };
                await _db.InvoiceItem.CreateAsync(invoiceItem);
            }

            var invoiceVm = new InvoiceVm() {
                Id = validInvoice.Id,
                Address = validInvoice.Address,
                PayableAmount = validInvoice.PayableAmount,
                CreationDate = validInvoice.CreationDate,
                PermitGenerationId = validInvoice.PermitGenerationId,
                TotalTerms = validInvoice.TotalTerms,
                TotalAmount = validInvoice.TotalAmount,
                UserId = validInvoice.UserId
            };


            result.Id = invoiceVm.Id;
            result.Extra = invoiceVm;
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] InvoiceVm invoice) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var validInvoice = await _db.Invoice.Find(invoice.Id);
            validInvoice.Id = invoice.Id;
            validInvoice.UserId = invoice.UserId;

            var result = await _db.Invoice.EditAsync(validInvoice);
            result.Id = invoice.Id;
            result.Extra = invoice;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var invoice = await _db.Invoice.Find(id);

            if (invoice == null) {
                return NotFound();
            }

            var result = await _db.Invoice.DeleteAsync(invoice);

            result.Id = invoice.Id;
            result.Extra = invoice;
            return Ok(result);
        }
    }
}




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
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public TransactionController(IUnitOfWork db) {
            _db = db;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionVm transaction) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            transaction.CreationDate = DateTime.Now;

            var validTransaction = new Transaction() {
                Id = transaction.Id,
                BankName = transaction.BankName,
                TrackingCode = transaction.TrackingCode,
                Amount = transaction.Amount,
                CreationDate = transaction.CreationDate,
                IsSuccess = transaction.IsSuccess,
                Description = transaction.Description
            };

            var result = await _db.Transactions.CreateAsync(validTransaction);
            result.Id = validTransaction.Id;
            result.Extra = validTransaction;
            return Ok(result);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var transactions = await _db.Transactions.GetAll().
                Select(s => new TransactionVm {
                    Id = s.Id,
                    BankName = s.BankName,
                    CreationDate = s.CreationDate,
                    Description = s.Description,
                    IsSuccess = s.IsSuccess,
                    TrackingCode = s.TrackingCode,
                    Amount = s.Amount
                })
               .PaginateObjects(page, pageSize)
               .ToListAsync();
            return Ok(transactions);
        }

    }
}


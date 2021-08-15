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

    public class WalletLogController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public WalletLogController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.WalletLogs.GetAll().
                Select(s => new WalletLogVm
                {
                    CreationDate = s.CreationDate,
                    Description = s.Description,
                    Id = s.Id,
                    TransactionId = s.TransactionId,
                    UserId = s.UserId,
                    WalletValue = s.WalletValue,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName
                }
                ).PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);

        }
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var WalletLog = await _db.WalletLogs.Find(id);
            if (WalletLog == null)
            {
                return NotFound();
            }
            return Ok(WalletLog);


        }
        [HttpGet]
        public async Task<IActionResult> GetWalletValue(int userId)
        {
            var walletValue =await _db.WalletLogs.GetAll()
                 .Where(n => n.UserId == userId)
                 .SumAsync(n => n.WalletValue);
            return Ok(walletValue);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int transactionId)
        {

            var transact = await _db.Transactions.Find(transactionId);

            var walletlog = new WalletLog
            {
                CreationDate = DateTime.Now,
                Description = transact.Description,
                UserId = User.GetUserId(),
                WalletValue = transact.Amount,
                TransactionId = transactionId,


            };
            var result = await _db.WalletLogs.CreateAsync(walletlog);
            result.Id = walletlog.Id;
            result.Extra = walletlog;
            return Ok(result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Edit([FromBody] WalletLog walletLog)
        //{
        //    var oldWalletLog = await _db.WalletLogs.Find(walletLog.Id);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var walletLog = await _db.WalletLogs.Find(id);
        //    if (walletLog == null)
        //    {
        //        return NotFound();
        //    }
        //    var result = await _db.WalletLogs.DeleteAsync(walletLog);
        //    result.Id = id;
        //    result.Extra = walletLog;
        //    return Ok(walletLog);
        //}
    }
}

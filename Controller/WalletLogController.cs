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
                ).PaginateObjects().ToListAsync();
            return Ok(list);

        }
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var WalletLog = await _db.WalletLogs.Find(id);
            if (WalletLog == null)
                return NotFound();
            return Ok(WalletLog);


        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WalletLog walletLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            walletLog.CreationDate = DateTime.Now;
            walletLog.UserId = User.GetUserId();
            Transaction transact = new Transaction();
            walletLog.TransactionId = transact.Id;
            var result = await _db.WalletLogs.CreateAsync(walletLog);
            result.Id = walletLog.Id;
            result.Extra = walletLog;
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] WalletLog walletLog)
        {
            var oldWalletLog = await _db.WalletLogs.Find(walletLog.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            walletLog.UserId = oldWalletLog.UserId;
            walletLog.TransactionId = oldWalletLog.TransactionId;
            walletLog.Id = oldWalletLog.Id;
            // change creationdate for modified date or not?
            var result = await _db.WalletLogs.EditAsync(walletLog);
            result.Id = walletLog.Id;
            result.Extra = walletLog;
            return Ok(walletLog);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var walletLog= await _db.WalletLogs.Find(id);
            if (walletLog == null)
            {
                return NotFound();
            }
            var result = await _db.WalletLogs.DeleteAsync(walletLog);
            result.Id = id;
            result.Extra = walletLog;
            return Ok(walletLog);
        }
    }
}

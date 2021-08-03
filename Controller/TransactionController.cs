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
    //[Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public TransactionController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var transactions = await _db.Transactions.GetAll().
                Select(s => new TransactionVm
                {
                    
                })
               .PaginateObjects().ToListAsync();
            return Ok(transactions);

        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var transaction = await _db.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }
}
        
}


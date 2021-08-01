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
    [Route("api/[controller]")]
    [ApiController]
    public class CreditTypeController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public CreditTypeController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var list = await _db.CreditTypes.GetAll().
                Select(s => new CreditTypeVm
                {
                    Id = s.Id,
                    AdminId = s.AdminId,
                    Title = s.Title,
                    Description = s.Description,
                    CreditPrice =s.CreditPrice,
                    CreditAmount = s.CreditAmount,
                    IsActive = s.IsActive ,
                    CreationDate=s.CreationDate,
                }
                ).PaginateObjects(page,pageSize).ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            if (!await _db.CreditTypes.IsExists(id))
            {
                return NotFound();
            }
            var creditType = await _db.CreditTypes.Find(id);
            return Ok(creditType);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditType creditType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            creditType.AdminId = User.GetUserId();
            creditType.IsActive = true;
            creditType.CreationDate = DateTime.Now;
            await _db.CreditTypes.CreateAsync(creditType);
            return Ok(creditType);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CreditType creditType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _db.CreditTypes.EditAsync(creditType);
            result.Id = creditType.Id;
            result.Extra = creditType;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var creditType = _db.CreditTypes.Find(id);
            if (creditType == null)
            {
                return NotFound();
            }
            var result = await _db.CreditTypes.DeleteAsync(id);
            result.Id = id;
            result.Extra = creditType;
            return Ok(result);
        }
    }
}

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
    public class CreditTypeController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public CreditTypeController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var list = await _db.CreditTypes.GetAll().
                Select(s => new CreditTypeVm {
                    Id = s.Id,
                    AdminId = s.AdminId,
                    Title = s.Title,
                    Description = s.Description,
                    CreditPrice = s.CreditPrice,
                    CreditAmount = s.CreditAmount,
                    IsActive = s.IsActive,
                    CreationDate = s.CreationDate,
                }
                ).PaginateObjects(page, pageSize).ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            if (!await _db.CreditTypes.IsExists(id)) {
                return NotFound();
            }
            var creditType = await _db.CreditTypes.Find(id);
            return Ok(creditType);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditTypeVm creditTypeVm) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            CreditType creditType = new CreditType()
            {
                AdminId = User.GetUserId(),
                CreationDate = DateTime.Now,
                CreditAmount = creditTypeVm.CreditAmount,
                CreditPrice = creditTypeVm.CreditPrice,
                Description = creditTypeVm.Description,
                Id = creditTypeVm.Id,
                IsActive = creditTypeVm.IsActive,
                Title = creditTypeVm.Title,
                
            };
            var result = await _db.CreditTypes.CreateAsync(creditType);
            result.Id = creditType.Id;
            result.Extra = creditType;
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CreditTypeVm creditTypeVm) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var validCreditType = await _db.CreditTypes.Find(creditTypeVm.Id);

            validCreditType.AdminId = User.GetUserId();
            validCreditType.Title = creditTypeVm.Title;
            validCreditType.Description = creditTypeVm.Description;
            validCreditType.CreditPrice = creditTypeVm.CreditPrice;
            validCreditType.CreditAmount = creditTypeVm.CreditAmount;
            validCreditType.IsActive = creditTypeVm.IsActive;
            validCreditType.CreationDate = creditTypeVm.CreationDate;

            var result = await _db.CreditTypes.EditAsync(validCreditType);
            result.Id = creditTypeVm.Id;
            result.Extra = creditTypeVm;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var creditType = _db.CreditTypes.Find(id);
            if (creditType == null) {
                return NotFound();
            }
            var result = await _db.CreditTypes.DeleteAsync(id);
            result.Id = id;
            result.Extra = creditType;
            return Ok(result);
        }
    }
}

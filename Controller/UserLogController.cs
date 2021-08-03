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
    public class UserLogController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public UserLogController(IUnitOfWork db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var usersLog = await _db.UserLogs.GetAll().
                Select(s => new UserLogsVm
                {
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    IsLogin = s.IsLogin,
                    UserDevice = s.UserDevice,
                    UserId = s.UserId,
                    UserIp = s.UserIp,
                    UserFullName = s.User.Person.FirstName + " " + s.User.Person.LastName
                })
                .PaginateObjects(page, pageSize).ToListAsync();
            return Ok(usersLog);
        }
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var userLog = await _db.UserLogs.Find(id);
            if (userLog == null)
            {
                return NotFound();
            }
            return Ok(userLog);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserLogs userLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userLog.CreationDate = DateTime.Now;
            userLog.UserId = User.GetUserId();
            userLog.IsLogin = 1;
            var userLogResult = await _db.UserLogs.CreateAsync(userLog);
            return Ok(userLogResult);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UserLogs userLog)
        {
            var oldUserLog = await _db.UserLogs.Find(userLog.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userLog.Id = oldUserLog.Id;
            userLog.UserId = oldUserLog.UserId;
            var result = await _db.UserLogs.EditAsync(userLog);
            result.Id = userLog.Id;
            result.Extra = userLog;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userLog = await _db.UserLogs.Find(id);
            if (userLog == null)
            {
                return NotFound();
            }
            var result = await _db.UserLogs.DeleteAsync(userLog);
            result.Id = userLog.Id;
            result.Extra = userLog;
            return Ok(result);
        }
    }
}

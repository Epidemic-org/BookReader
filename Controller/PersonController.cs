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
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public PersonController(IUnitOfWork db) {
            _db = db;
        }

        /// <summary>
        /// Returns a person object
        /// </summary>
        /// <param name="id">Gets the id corresponds to the person object</param>
        /// <returns>Person</returns>
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] int id) {
            var validPerson = await _db.People.FindbyUserId(id);

            if (validPerson == null) {
                return NotFound();
            }

            var person = new PersonVm() {
                Id = validPerson.Id,
                UserId = validPerson.UserId,
                FirstName = validPerson.FirstName,
                LastName = validPerson.LastName,
                NationalCode = validPerson.NationalCode,
                Phone = validPerson.Phone,
            };
            return Ok(person);
        }

        /// <summary>
        /// Edit<s the person
        /// </summary>
        /// <param name="person">Gets a person object as parameter</param>
        /// <returns>Person</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PersonPostVM person) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }            
            var validUser = await _db.AppUsers.Find(User.GetUserId());
            var validPerson = await _db.People.FindbyUserId(validUser.Id);

            validPerson.UserId = person.UserId;
            validPerson.FirstName = person.FirstName;
            validPerson.LastName = person.LastName;
            validPerson.NationalCode = person.NationalCode;
            validUser.Email = person.Email;

            var result = await _db.People.EditAsync(validPerson);
            result.Id = person.Id;
            result.Extra = person;
            return Ok(person);
        }
    }
}

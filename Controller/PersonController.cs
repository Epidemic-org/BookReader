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
        public async Task<IActionResult> FindById(int userId) {
            var validPerson = await _db.People.Find(userId);

            if (validPerson == null) {
                return NotFound();
            }
            var person = new PersonVm() {
                Id = validPerson.Id,
                UserId = validPerson.UserId,
                FirstName = validPerson.FirstName,
                LastName = validPerson.LastName,
                BirthDate = validPerson.BirthDate,
                NationalCode = validPerson.NationalCode,
                Pic = validPerson.Pic,
                Phone = validPerson.Phone,
                JobType = validPerson.JobType,
                CreationDate = validPerson.CreationDate,
                IsAcceptRules = validPerson.IsAcceptRules
            };

            return Ok(person);
        }

        /// <summary>
        /// Edit<s the person
        /// </summary>
        /// <param name="person">Gets a person object as parameter</param>
        /// <returns>Person</returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Person person) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            Person validPerson;

            var validUser = await _db.AppUsers.Find(User.GetUserId());

            if (_db.AppUsers.GetAll(u => u.Id == User.GetUserId()).Where(u => u.Person == null).Any()) {
                validPerson = new Person();
                validUser.Person = validPerson;
            }
            else {
                validPerson = validUser.Person;
            }

            validPerson.UserId = User.GetUserId();
            validPerson.FirstName = person.FirstName;
            validPerson.LastName = person.LastName;
            validPerson.BirthDate = person.BirthDate;
            validPerson.NationalCode = person.NationalCode;
            validPerson.Pic = person.Pic;
            validPerson.Phone = person.Phone;
            validPerson.GenderType = person.GenderType;
            validPerson.JobType = person.JobType;
            validPerson.IsAcceptRules = person.IsAcceptRules;
            validPerson.CreationDate = person.CreationDate;

            var result = await _db.People.EditAsync(person);
            result.Id = person.Id;
            result.Extra = person;
            return Ok(person);
        }
    }
}

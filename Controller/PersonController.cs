using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
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
        /// Returns list of persons
        /// </summary>
        /// <returns>List of type Person</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) {
            var people = await _db.People.GetAll()
                .Select(p => new Person() {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    Phone = p.Phone,
                    NationalCode = p.NationalCode,
                    GenderType = p.GenderType,
                    JobType = p.JobType,
                    UserId = p.UserId,
                    CreationDate = p.CreationDate,
                    IsAcceptRules = p.IsAcceptRules
                })
                .PaginateObjects(page, pageSize)
                .ToListAsync();
            return Ok(people);
        }

        /// <summary>
        /// Returns a person object
        /// </summary>
        /// <param name="id">Gets the id corresponds to the person object</param>
        /// <returns>Person</returns>
        [HttpGet]
        public async Task<IActionResult> FindById() {
            var userId = User.GetUserId();
            var validUser = await _db.AppUsers.Find(userId);

            var person = await _db.People.Find(validUser.Person.Id);

            if (person == null) {
                return NotFound();
            }
            return Ok(person);
        }

        /// <summary>
        /// Insert new person
        /// </summary>
        /// <param name="person">Gets a person object from body</param>
        /// <returns>Person</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            person.UserId = User.GetUserId();
            person.CreationDate = DateTime.Now;

            var result = await _db.People.CreateAsync(person);
            result.Id = person.Id;
            result.Extra = person;
            return Ok(result);
        }

        /// <summary>
        /// Edits the person
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

            if (_db.AppUsers.GetAll(u => u.Id == User.GetUserId()).Where(u=> u.Person == null).Any()) {
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var person = await _db.People.Find(id);
            if (person == null) {
                return NotFound();
            }
            var result = await _db.People.DeleteAsync(person);
            result.Id = id;
            result.Extra = person;
            return Ok(person);
        }
    }
}

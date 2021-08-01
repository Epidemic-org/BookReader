using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class ProductRateController : ControllerBase
    {
        private IUnitOfWork _db;
        public ProductRateController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET: api/<ProductRateController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.ProductRates.GetAll().
                Select(s => new ProductRateVm
                {
                    Id = s.Id,
                    UserId = s.UserId ,
                    ProductId = s.ProductId,
                    RateValue = s.RateValue,
                    CreationDate = s.CreationDate
                }
                ).PaginateObjects().ToListAsync();
            return Ok(list);
        }

        // GET api/<ProductRateController>/5
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var productRate = await _db.ProductRates.Find(id);
            if (productRate == null) return NotFound();
            else return Ok(productRate);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRate productRate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            productRate.UserId = User.GetUserId();
            productRate.CreationDate = System.DateTime.Now;
            var result = await _db.ProductRates.CreateAsync(productRate);
            result.Id = productRate.Id;
            result.Extra = productRate;
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductRate productRate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _db.ProductRates.EditAsync(productRate);
            result.Id = productRate.Id;
            result.Extra = productRate;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productRate = await _db.ProductRates.Find(id);
            if (productRate == null) return NotFound();
            var result = await _db.ProductRates.DeleteAsync(productRate);
            result.Id = id;
            result.Extra = productRate;
            return Ok(result);
        }
    }
}

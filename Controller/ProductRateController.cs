using BookReader.Context;
using BookReader.Data.Models;
using BookReader.Utillities;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookReader.Controller
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    [Authorize]
    public class ProductRateController : ControllerBase
    {
        private IUnitOfWork _db;
        public ProductRateController(IUnitOfWork db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRateVm productRate) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            productRate.UserId = User.GetUserId();
            productRate.CreationDate = System.DateTime.Now;

            var validProduct = new ProductRate() {
                Id = productRate.Id,
                CreationDate = productRate.CreationDate,
                RateValue = productRate.RateValue,
                UserId = User.GetUserId()
            };

            var result = await _db.ProductRates.CreateAsync(validProduct);
            result.Id = productRate.Id;
            result.Extra = productRate;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var productRate = await _db.ProductRates.Find(id);

            if (productRate == null) {
                return NotFound();
            }

            var result = await _db.ProductRates.DeleteAsync(productRate);
            result.Id = id;
            result.Extra = productRate;
            return Ok(result);
        }
    }
}

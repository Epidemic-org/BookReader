using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookReader.Context;
using BookReader.Data.Models;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUnitOfWork _db;
        public AuthController(IUnitOfWork db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppUser user) {
            if (!ModelState.IsValid) {
                return BadRequest("The Model Is Not Valid");
            }
            AppUser appUser = await _db.AppUsers.Find(user.UserName);

            if (user.UserName.ToLower() != appUser.UserName || user.PasswordHash.ToLower() !=appUser.PasswordHash || appUser == null)
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Kasian"));

            var signinCredentials=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

            var tokenOption = new JwtSecurityToken(
                issuer: "http://localhost:32937",
                claims:new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                },
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:signinCredentials
            );
            
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return Ok(new {token = tokenString});
        }

    }
}
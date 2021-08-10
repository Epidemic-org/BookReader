
using BookReader.Context;
using BookReader.Context.Services;
using BookReader.Data.Models;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EshopApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork _db;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWork db, IConfiguration configuration, ITokenService tokenService)
        {
            _db = db;
            _config = configuration;
            _tokenService = tokenService;

            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var validUser = await _userManager.FindByNameAsync(userVM.UserName);
            if (validUser == null)
            {
                ModelState.AddModelError("not found user", "نام کاربری یا کلمه عبور اشتباه است.");
                return BadRequest(ModelState);
            }

            var result_password = await _signInManager.CheckPasswordSignInAsync(validUser, userVM.Password, false);

            if (!result_password.Succeeded)
            {
                ModelState.AddModelError("not found user", "نام کاربری یا کلمه عبور اشتباه است.");
                return BadRequest(ModelState);
            }

            generatedToken = _tokenService.BuildToken(key: _config["Jwt:Key"].ToString(),
                issuer: _config["Jwt:Issuer"].ToString(), validUser);
            if (generatedToken != null)
            {
                return Ok(new { UserId = validUser.Id, UserName = validUser.UserName, Token = generatedToken });
            }
            else
            {
                return NotFound("Token Buil Failed");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] LoginVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validUser = await _userManager.FindByNameAsync(userVM.UserName);
            if (validUser != null)
            {
                ModelState.AddModelError("not found user", "نام کاربری وجود دارد.");
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(new AppUser { UserName = userVM.UserName, IsActive = true, PhoneNumberConfirmed = true, EmailConfirmed = true }, userVM.Password);                        
            if (result.Succeeded)
            {
                return Ok(userVM);
            }

            return BadRequest(result.Errors);

        }
    }
}
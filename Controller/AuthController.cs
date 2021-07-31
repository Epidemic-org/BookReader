
using BookReader.Context;
using BookReader.Context.Services;
using BookReader.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


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


        public AuthController(IUnitOfWork db, IConfiguration configuration, ITokenService tokenService) {
            _db = db;
            _config = configuration;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginVM userVM) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            IActionResult response = Unauthorized();
            var validUser = _db.AppUsers.GetUser(userVM);
            if (validUser != null) {
                generatedToken = _tokenService.BuildToken(key: _config["Jwt:Key"].ToString(),
                    issuer: _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null) {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return Ok(new { token = generatedToken });
                }
                else {
                    return NotFound("Token Buil Failed");
                }
            }
            else {
                return NotFound("Valid User is null");
            }
        }
    }
}
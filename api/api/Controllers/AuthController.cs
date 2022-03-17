using api.Dto;
using api.Helpers;
using api.IData;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthenticationRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthDto userDto)
        {
            DateTime tokenExpiry = DateTime.Now.AddHours(1);
            userDto.Username = userDto.Username.ToLower();
            var user = await _repo.Login(userDto);

            if (user == null)
                return Unauthorized("Incorrect username and/or password.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiry,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user.Username,
                tokenExpiry
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]AuthDto authDto)
        {
            DateTime tokenExpiry = DateTime.Now.AddHours(1);
            authDto.Username = authDto.Username.ToLower();

            if (await _repo.UserExists(authDto.Username))
                return BadRequest("Username already exists.");

            var user = new User()
            {
                Username = authDto.Username
            };

            var createdUser = await _repo.Register(user, authDto.Password);

            //return CreatedAtRoute("GetUser", new { Controller = "Users", id = createdUser.UserID }, createdUser.Username);
            //return Ok(createdUser.Username);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, createdUser.Username.ToString()),
                new Claim(ClaimTypes.Name, createdUser.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiry,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                createdUser.Username,
                tokenExpiry = tokenExpiry.ToString()
            });
        }
    }
}

using DataAccess.UnitOfWorks;
using Entities.Clients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Web.Dtos;
using Web.Helpers;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IConfiguration Config;

        public AuthController(IUnitOfWork unitOfWork,
            IConfiguration config)
        {
            UnitOfWork = unitOfWork;
            Config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            var person = UnitOfWork.PersonRepository.FindByEmail(login.Username);
            if (person == null)
            {
                return NotFound();
            }
            var hashedPassword = PasswordOperation.HashPassword(login.Password);
            if (hashedPassword == person.Password)
            {
                return SuccessLogin(person);
            }
            else
            {
                return Unauthorized();
            }
        }

        //DRY  -> Don't repeat yourself

        [HttpPost("Refresh")]
        public IActionResult Refresh()
        {
            var canRetrieve = this.HttpContext.Request.Cookies.TryGetValue("RefreshToken", out string? refreshToken);
            if (canRetrieve)
            {
                var person = UnitOfWork.PersonRepository.Gets(x => x.RefreshToken == refreshToken).FirstOrDefault();
                if(person == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return SuccessLogin(person);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        private IActionResult SuccessLogin(PersonEntity person)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("name", person.Name));
            claims.Add(new Claim("permissions", "delete"));
            claims.Add(new Claim("permissions", "add"));

            var token = new JwtSecurityToken(
                issuer: Config.GetSection("Jwt:Issuer").Value,
                audience: Config.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Config.GetSection("Jwt:SecretKey").Value)),
                    SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenText = tokenHandler.WriteToken(token);
            string refreshToken = TokenGenerator.GenerateRefreshToken();
            person.RefreshToken = refreshToken;
            UnitOfWork.PersonRepository.Update(person);
            UnitOfWork.SaveChanges();
            this.HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            });
            return Ok(tokenText);
        }
    }
}

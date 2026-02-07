using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Web.Dtos;
using Web.Helpers;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AutheticationController : BaseCustomController
    {
        public AutheticationController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var person = UnitOfWork.PersonRepository.FindByEmail(login.Username);
            if(person == null)
            {
                TempData.Add("Error", "Istifadeci tapilmadi");
                return View();
            }
            var hashedPassword = PasswordOperation.HashPassword(login.Password);
            if(hashedPassword == person.Password)
            {
                var principial = new ClaimsPrincipal();
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("name", person.Name));
                if(person.Name.ToLower() == "murad")
                {
                    identity.AddClaim(new Claim("canDeleteUser", "true"));
                }
                else
                {
                    identity.AddClaim(new Claim("canDeleteUser", "false"));
                }
                principial.AddIdentity(identity);
                await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(principial));
                this.HttpContext.Session.SetInt32("IsAuthenticate", 0);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("Error", "Parol duzgun deyil");
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}

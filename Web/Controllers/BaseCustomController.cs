using DataAccess.EfImplementations;
using DataAccess.EfImplementations.Contexts;
using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class BaseCustomController : Controller
    {
        protected IUnitOfWork UnitOfWork;

        public BaseCustomController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Web.Filters;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class TestController : ControllerBase
    {
        public TestController() 
        {
        }

        [HttpGet]
        [ServiceFilter<PerformanceFilter>]
        [ServiceFilter<AgeFilter>]
        public IActionResult Hi()
        {
            Thread.Sleep(1500);
            //throw new Exception("Test exception");
            return Ok("Salam");
        }

        /*
[HttpGet("MockPeople")]
public async Task GetMockPeople()
{

   var people = new List<PersonDto>
   {
       new PersonDto
       {
           Name = "Test1",
           Surname = "STest1",
           PersonSalary = 1.5m,
           Age = 1,
           Email = "1@mail.ru",
           BirthDate = DateTime.Now,
           HasPassport = false,
           Mobiles = new List<MobilPhoneDto>
           {
               new MobilPhoneDto
               {
                   Id = 1,
                   Phone = "0993991913"
               },
               new MobilPhoneDto
               {
                   Id = 2,
                   Phone = "0554236578"
               }
           }
       },
       new PersonDto
       {
           Name = "Test2",
           Surname = "STest2",
           BirthDate = DateTime.Now.AddYears(-3).AddDays(-20),
           PersonSalary= 2.5m,
           Age = 2,
           Email = "2@mail.ru",
           HasPassport = true,
           Mobiles = new List<MobilPhoneDto>
           {
               new MobilPhoneDto
               {
                   Id = 3,
                   Phone = "0512345612"
               },
               new MobilPhoneDto
               {
                   Id = 1,
                   Phone = "0778994575"
               }
           }
       },
   };
   var json = JsonSerializer.Serialize(people);

   // convert to StreamContent
   var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
   stream.Position = 0;
   this.HttpContext.Response.StatusCode = 500;
   this.Response.Headers.ContentLength = stream.Length;
   this.HttpContext.Response.Headers.ContentType = "application/json";

   await stream.CopyToAsync(HttpContext.Response.Body);
   //return Ok(people);
}
*/

    }
}

using AutoMapper;
using DataAccess.EfImplementations;
using DataAccess.EfImplementations.Contexts;
using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;
using Web.Models;
using Web.Models.TestMvc;

namespace Web.Controllers
{
    public class TestMvcController : BaseCustomController
    {
        private readonly IMapper _mapper;
        public TestMvcController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            this.HttpContext.Session.SetString("data", "emin necedir");
            var person = UnitOfWork.PersonRepository.FindByEmail("davud@gmail.com");
            var lessons = UnitOfWork.LessonRepository.Gets();
            IndexViewModel viewModel = new IndexViewModel
            {
                Person = _mapper.Map<PersonDto>(person),
                Lessons = lessons.Select(x => new Dtos.LessonDto(x)).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Davud()
        {
            return View();
        }
    }
}

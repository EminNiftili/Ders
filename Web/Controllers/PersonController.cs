using AutoMapper;
using DataAccess.UnitOfWorks;
using Entities.Clients;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;
using Web.Helpers;
using Web.Models.Person;
using Web.Validations;

namespace Web.Controllers
{
    public class PersonController : BaseCustomController
    {
        private readonly IValidator<AddPersonDto> _validator;
        private readonly IMapper _mapper;
        public PersonController(IUnitOfWork unitOfWork, 
            IValidator<AddPersonDto> validator,
            IMapper mapper) : base(unitOfWork)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var data = this.HttpContext.Session.GetString("data");
            var personEntities = UnitOfWork.PersonRepository.Gets().ToList();
            var people = _mapper.Map<List<PersonDto>>(personEntities);
            IndexViewModel viewModel = new IndexViewModel
            {
                People = people
            };
            return View(viewModel);
        }

        public IActionResult AddPerson()
        {
            AddPersonViewModel viewModel = new AddPersonViewModel();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddPersonData(AddPersonDto addPersonDto)
        {
            List<string> errors = new List<string>();

            var validationResult = _validator.Validate(addPersonDto);

            if(validationResult.IsValid)
            {
                try
                {
                    var hashedPassword = PasswordOperation.HashPassword(addPersonDto.Password);
                    PersonEntity personEntity = new PersonEntity
                    {
                        Name = addPersonDto.Name,
                        Surname = addPersonDto.Surname,
                        Email = $"{addPersonDto.EmailAdress}@{addPersonDto.EmailServer}",
                        Age = (byte)addPersonDto.Age,
                        PersonSalary = addPersonDto.Salary,
                        Password = hashedPassword,
                    };
                    UnitOfWork.PersonRepository.Add(personEntity);
                    UnitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    errors.Add("Bazayla bağlı xəta baş verdi!");
                    return View("AddPerson", new AddPersonViewModel
                    {
                        Errors = errors,
                        Person = addPersonDto
                    });
                }
            }
            else
            {
                errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return View("AddPerson", new AddPersonViewModel
                {
                    Errors = errors,
                    Person = addPersonDto
                });
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePerson(int id)
        {
            UnitOfWork.PersonRepository.Delete(id);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

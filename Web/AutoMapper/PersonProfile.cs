using AutoMapper;
using Entities.Clients;
using Web.Dtos;

namespace Web.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonEntity, PersonDto>()
                .ForMember(x => x.Salary, opt => opt.MapFrom(z => z.PersonSalary))
                .ForMember(x => x.Mobiles, davud => davud.MapFrom(z => z.PersonMobiles.Select(x => x.Mobile).ToList()))
                .ReverseMap();

            CreateMap<MobileEntity, MobileDto>()
                .ReverseMap();
        }
    }
}

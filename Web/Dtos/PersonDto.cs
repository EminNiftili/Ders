using Entities.Clients;

namespace Web.Dtos
{
    public class PersonDto
    {
        public PersonDto()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte Age { get; set; }
        public decimal Salary { get; set; }
        public IEnumerable<MobileDto> Mobiles { get; set; } = new List<MobileDto>();
    }
}

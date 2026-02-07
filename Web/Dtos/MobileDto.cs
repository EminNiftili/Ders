using Entities.Clients;
using Entities.Compositions;

namespace Web.Dtos
{
    public class MobileDto
    {
        public MobileDto()
        {
        }

        public int Id { get; set; }
        public string Number { get; set; } = null!;
    }
}

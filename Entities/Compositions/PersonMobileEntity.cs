using Entities.Clients;

namespace Entities.Compositions
{
    public class PersonMobileEntity : BaseEntity
    {
        public int PersonId { get; set; }
        public int PhoneNumberId { get; set; }
        public PersonEntity? Person { get; set; }
        public MobileEntity? Mobile { get; set; }
    }
}

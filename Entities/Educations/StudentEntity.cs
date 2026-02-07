using Entities.Clients;

namespace Entities.Educations
{
    public class StudentEntity : BaseEntity
    {
        public int PersonId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime BirthDate { get; set; }

        public PersonEntity? Person { get; set; }
    }
}

using Entities.Compositions;
using Entities.Educations;

namespace Entities.Clients
{
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte Age { get; set; }
        public decimal PersonSalary { get; set; }
        public string Password { get; set; } = null!;
        public string? RefreshToken { get; set; }


        public StudentEntity? Student { get; set; }
        public IdentityCardEntity? IdentityCard { get; set; }
        public ICollection<SalaryHistoryEntity> SalaryHistories { get; set; } = new List<SalaryHistoryEntity>();
        public ICollection<PersonMobileEntity> PersonMobiles { get; set; } = new List<PersonMobileEntity>();
        public ICollection<PersonLessonEntity> PersonLessons { get; set; } = new List<PersonLessonEntity>();
    }
}

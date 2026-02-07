using Entities.Compositions;

namespace Entities.Educations
{
    public class LessonEntity : BaseEntity
    {
        public string SpecialtyName { get; set; } = null!;
        public string FacultyName { get; set; } = null!;

        public ICollection<PersonLessonEntity> PersonLessons { get; set; } = new List<PersonLessonEntity>();
    }
}

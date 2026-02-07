using Entities.Educations;
using Entities.Clients;

namespace Entities.Compositions
{
    public class PersonLessonEntity : BaseEntity
    {
        public int PersonId { get; set; }
        public int LessonId { get; set; }

        public PersonEntity? Person { get; set; }
        public LessonEntity? Lesson { get; set; }
    }
}

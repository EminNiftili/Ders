using Entities.Educations;

namespace Web.Dtos
{
    public class LessonDto
    {
        public LessonDto(LessonEntity entity)
        {
            Id = entity.Id;
            SpecialtyName = entity.SpecialtyName;
            FacultyName = entity.FacultyName;
        }

        public int Id { get; set; }
        public string SpecialtyName { get; set; } = null!;
        public string FacultyName { get; set; } = null!;
    }
}

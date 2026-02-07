using Web.Dtos;

namespace Web.Models.TestMvc
{
    public class IndexViewModel
    {
        public PersonDto Person { get; set; } = null!;
        public List<LessonDto>? Lessons { get; set; }
    }
}

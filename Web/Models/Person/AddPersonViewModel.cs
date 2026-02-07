using Web.Dtos;

namespace Web.Models.Person
{
    public class AddPersonViewModel
    {
        public AddPersonDto? Person { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}

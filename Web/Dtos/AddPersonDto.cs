using System.ComponentModel.DataAnnotations;

namespace Web.Dtos
{
    public class AddPersonDto
    {
        [Required(ErrorMessageResourceName = "Ad mecburidir")]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string EmailAdress { get; set; }

        [Required]
        [EmailAddress]
        public string EmailServer { get; set; }

        [Required]
        [Range(18,50)]
        public int Age { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

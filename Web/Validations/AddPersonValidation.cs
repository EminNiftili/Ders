using FluentValidation;
using Web.Dtos;

namespace Web.Validations
{
    public class AddPersonValidation : AbstractValidator<AddPersonDto>
    {
        public AddPersonValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name cannot be empty.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                    .WithMessage("Surname cannot be empty.");

            RuleFor(x => x.EmailAdress)
                .NotEmpty()
                    .WithMessage("EmailAdres cannot be empty.");

            RuleFor(x => x.EmailServer)
                .NotEmpty()
                    .WithMessage("EmailAdres cannot be empty.");

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 255)
                    .WithMessage("Age must be between 0 and 255.")
                .When(x => x.Salary > 3000)
                .Must(x => x > 18)
                     .WithMessage("Maasi 300-den yuxari olan musteri yasi 18-den az ola bilmez");

            RuleFor(x => x.Salary)
                .GreaterThan(345)
                    .WithMessage("Salary must be greater than Minumum wage.");


            //REGEX -> regular expression
            RuleFor(x => x.Password)
                .MinimumLength(8)
                    .WithMessage("Password cannot be less 8 symbols")
                .Matches("[A-Z]")
                    .WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]")
                    .WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[!@#$%^&*(),.?\":{}|<>]")
                    .WithMessage("Password must contain at least one special character.")
                .Must(MustHas2Digit)
                    .WithMessage("Password must contain at least two digits.");



        }


        private bool MustHas2Digit(string password)
        {
            int digitCount = 0;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }
            return digitCount >= 2;
        }
    }
}

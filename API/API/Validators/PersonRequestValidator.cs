using API.Models.Requests;
using FluentValidation;

namespace API.Validators
{
    public class PersonRequestValidator : AbstractValidator<PersonRequest>
    {
        public PersonRequestValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .MaximumLength(11)
                .WithName("CPF");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(255)
                .WithName("Email");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255)
                .WithName("Nome");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11)
                .WithName("Celular");
        }
    }
}
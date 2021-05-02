using Domain.Models;
using FluentValidation;

namespace Domain.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(13);
        }
    }
}
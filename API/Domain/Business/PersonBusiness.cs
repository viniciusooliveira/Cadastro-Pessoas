using Domain.Business.Bases;
using Domain.Business.Contracts;
using Domain.Models;
using Domain.Repositories;
using FluentValidation;

namespace Domain.Business
{
    public class PersonBusiness : BaseValidationBusiness<Person, IPersonRepository>, IPersonBusiness
    {
        public PersonBusiness(IPersonRepository repository, AbstractValidator<Person> validator) 
            : base(repository, validator)
        {
        }
    }
}
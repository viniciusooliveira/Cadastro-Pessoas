using Domain.Business.Contracts.Bases;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Contracts;

namespace Domain.Business.Contracts
{
    public interface IPersonBusiness : IBaseValidationBusiness<Person, IPersonRepository>
    {
        
    }
}
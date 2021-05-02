using System.Threading.Tasks;
using Domain.Models.Bases;
using FluentValidation;

namespace Domain.Business.Contracts
{
    public interface IBaseValidationBusiness<TModel, TRepository> : IBaseBusiness<TModel, TRepository>
        where TModel : Identifiable
    {
        Task<bool> Validate(TModel model);
    }
}
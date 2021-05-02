using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Bases;
using FluentValidation;

namespace Domain.Business.Contracts
{
    public interface IBaseBusiness<TModel, TRepository>
        where TModel : Identifiable
    {
        Task<TModel> Get(Identifiable identifiable);

        Task<IList<TModel>> ListAll();

        Task<TModel> Save(TModel model);

        Task<TModel> Delete(Identifiable identifiable);
    }
    
}
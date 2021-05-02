using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrossCutting.Mappers.Contracts;
using Domain.Models.Bases;

namespace Domain.Repositories.Contracts
{
    public interface IBaseRepository<TModel> 
        where TModel : Identifiable
    {
        Task<TModel> Get(Identifiable identifiable);

        Task<IList<TModel>> ListAll();

        Task<TModel> Save(TModel model);

        Task<TModel> Delete(Identifiable identifiable);
    }
    
    public interface IBaseRepository<TModel, TEntity> : IBaseRepository<TModel>
        where TModel : Identifiable
        where TEntity : Identifiable, IObjectMapper<TModel, TEntity>
    {
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Business.Contracts;
using Domain.Business.Contracts.Bases;
using Domain.Models.Bases;
using Domain.Repositories.Contracts;

namespace Domain.Business.Bases
{
    public class BaseBusiness<TModel, TRepository> : IBaseBusiness<TModel, TRepository>
        where TModel : Identifiable
        where TRepository : IBaseRepository<TModel>
    {
        private readonly TRepository _repository;

        protected TRepository GetRepository() => _repository;
        
        public BaseBusiness(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<TModel> Get(Identifiable identifiable)
            => await _repository.Get(identifiable);

        public virtual async Task<IList<TModel>> ListAll()
            => await _repository.ListAll();

        public virtual async Task<TModel> Save(TModel model)
            => await _repository.Save(model);


        public virtual async Task<TModel> Delete(Identifiable identifiable)
            => await _repository.Delete(identifiable);
    }
}
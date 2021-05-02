using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Business.Contracts;
using Domain.Business.Contracts.Bases;
using Domain.Models.Bases;
using Domain.Repositories.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Business.Bases
{
    public class BaseValidationBusiness<TModel, TRepository> : BaseBusiness<TModel, TRepository>, 
        IBaseValidationBusiness<TModel,TRepository>
        where TModel : Identifiable
        where TRepository : IBaseRepository<TModel>
    {
        private readonly AbstractValidator<TModel> _validator;

        protected AbstractValidator<TModel> GetValidator() => _validator;
        
        public BaseValidationBusiness(TRepository repository, AbstractValidator<TModel> validator) : base(repository)
        {
            _validator = validator;
        }

        public new virtual async Task<TModel> Save(TModel model)
        {
            await ValidateAndThrow(model);
            return await base.Save(model);
        }

        protected async Task ValidateAndThrow(TModel model)
        {
            await _validator.ValidateAndThrowAsync(model);
        }
        
        public async Task<bool> Validate(TModel model)
        {
            var result = await _validator.ValidateAsync(model);
            return result.IsValid;
        }
    }
}
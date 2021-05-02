using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.Mappers.Contracts;
using Domain.Contexts.Contracts;
using Domain.Models.Bases;
using Domain.Repositories.Contracts;
using Mariadb.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mariadb.Repositories.Bases
{
    public class BaseRepository<TModel, TEntity> : IBaseRepository<TModel, TEntity> 
        where TModel : Identifiable
        where TEntity : Identifiable, IObjectMapper<TModel, TEntity>, new()
    {
        private readonly WebpicContext _context;

        protected WebpicContext GetContext() => _context;

        public BaseRepository(IWebpicContext context)
        {
            _context = (WebpicContext) context;
        }
        
        public virtual async Task<TModel> Get(Identifiable identifiable)
        {
            var result = await _context.FindAsync<TEntity>(identifiable.Id);
            return result?.MapTo();
        }

        public virtual async Task<IList<TModel>> ListAll()
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result?.Select(x => x.MapTo()).ToList();
        }

        public virtual async Task<TModel> Save(TModel model)
        {
            var entity = new TEntity();
            entity.MapFrom(model);
            
            if (entity.Id == 0)
            {
                _context.Add(entity);
            }
            else
            {
                _context.Attach(entity);
                    
                var entry = _context.Entry(entity);

                entry.State = EntityState.Modified;
            }
                
            await _context.SaveChangesAsync();
                
            return entity?.MapTo();
        }

        public virtual async Task<TModel> Delete(Identifiable identifiable)
        {
            var entity = new TEntity()
            {
                Id = identifiable.Id
            };

            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return entity?.MapTo();
        }
    }
}
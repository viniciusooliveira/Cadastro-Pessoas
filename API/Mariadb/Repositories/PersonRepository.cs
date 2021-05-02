using Domain.Contexts.Contracts;
using Domain.Models;
using Domain.Repositories;
using Mariadb.Entities;
using Mariadb.Repositories.Bases;

namespace Mariadb.Repositories
{
    public class PersonRepository : BaseRepository<Person, PersonEntity>, IPersonRepository
    {
        public PersonRepository(IWebpicContext context) : base(context)
        {
        }
    }
}
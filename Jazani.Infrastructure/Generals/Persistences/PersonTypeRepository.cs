using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Persistences;
using Jazani.Infrastructure.Cores.Contexts;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class PersonTypeRepository : CrudRepository<PersonType, int>, IPersonTypeRepository
    {
        public PersonTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}


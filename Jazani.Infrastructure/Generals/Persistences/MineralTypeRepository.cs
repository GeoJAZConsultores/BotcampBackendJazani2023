using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.EntityFrameworkCore;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MineralTypeRepository : CrudRepository<MineralType, int>, IMineralTypeRepository
    {
        public MineralTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}


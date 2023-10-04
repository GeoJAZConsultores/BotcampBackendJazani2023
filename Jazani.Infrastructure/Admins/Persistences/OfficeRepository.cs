using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class OfficeRepository : CrudRepository<Office, int>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}


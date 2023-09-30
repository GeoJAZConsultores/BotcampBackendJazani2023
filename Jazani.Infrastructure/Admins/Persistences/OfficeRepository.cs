using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OfficeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Office>> FindAllAsync()
        {
            return await _dbContext.Offices.ToListAsync();
        }

        public async Task<Office?> FindByIdAsync(int id)
        {
            return await _dbContext.Offices
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Office> SaveAsync(Office office)
        {
            EntityState state = _dbContext.Entry(office).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Offices.Add(office),
                EntityState.Modified => _dbContext.Offices.Update(office)
            };


            await _dbContext.SaveChangesAsync();

            return office;
        }
    }
}


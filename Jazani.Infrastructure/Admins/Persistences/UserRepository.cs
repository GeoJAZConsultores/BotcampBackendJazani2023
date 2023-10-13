using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class UserRepository : CrudRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _dbContext.Set<User>()
                .Where(t => t.Email.ToUpper().Equals(email.ToUpper()))
                .FirstOrDefaultAsync();
        }
    }
}


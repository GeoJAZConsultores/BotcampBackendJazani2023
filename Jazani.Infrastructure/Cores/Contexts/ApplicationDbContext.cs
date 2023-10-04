using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Jazani.Infrastructure.Generals.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        #region "DbSet"
        public DbSet<Office> Offices { get; set; }
        public DbSet<MineralType> MineralTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new MineralTypeConfiguration());
        }

    }
}


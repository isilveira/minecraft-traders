using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Infrastructures.Data
{
    public class DefaultDbContext : DbContext, IDefaultDbContext
    {
        public DbSet<Sample> Samples { get; set; }

        protected DefaultDbContext()
        {
            base.Database.EnsureCreated();
        }
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }
    }
}

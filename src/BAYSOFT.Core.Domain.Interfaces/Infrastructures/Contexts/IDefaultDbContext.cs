using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts
{
    public interface IDefaultDbContext
    {
        DbSet<Sample> Samples { get; set; }
        DbSet<Villager> Villagers { get; set; }
        DbSet<Profession> Professions{ get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Trade> Trades{ get; set; }
        DbSet<Accept> Accepts { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<ProfessionItem> ProfessionItems { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

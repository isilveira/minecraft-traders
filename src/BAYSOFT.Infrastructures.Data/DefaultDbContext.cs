using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Infrastructures.Data
{
    public class DefaultDbContext : DbContext, IDefaultDbContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Villager> Villagers { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Accept> Accepts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ProfessionItem> ProfessionItems { get; set; }

        protected DefaultDbContext()
        {
            base.Database.EnsureCreated();
        }
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfessionItem>()
                .HasKey(x => new { x.ProfessionID, x.ItemID });
            modelBuilder.Entity<ProfessionItem>()
                .HasOne(x => x.Profession)
                .WithMany(x => x.ProfessionItems)
                .HasForeignKey(x=>x.ProfessionID);
            modelBuilder.Entity<ProfessionItem>()
                .HasOne(x => x.Item)
                .WithMany(x => x.ProfessionItems)
                .HasForeignKey(x => x.ItemID);
        } 
    }
}

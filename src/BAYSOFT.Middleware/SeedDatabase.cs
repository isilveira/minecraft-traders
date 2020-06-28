using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using ChanceNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Middleware
{
    public static class SeedDatabase
    {
        public static async Task Seed(this IDefaultDbContext context, IConfiguration configuration, CancellationToken cancellationToken)
        {
            var seedsMultiplier = configuration.GetSection("AppSettings").GetValue<int>("SeedsMultiplier");
            if (seedsMultiplier == 0)
            {
                Log.Debug("Seeds multiplier set to 0, no seeds generated!");
                return;
            }

            await context.SeedSamples(seedsMultiplier * 10, cancellationToken);
            await context.SeedProfessions(cancellationToken);
        }

        internal static async Task SeedSamples(this IDefaultDbContext context, int inserts, CancellationToken cancellationToken)
        {
            var totalSamples = await context.Samples.CountAsync(cancellationToken);

            while (totalSamples < inserts)
            {
                int saveCounter = 0;

                for (int i = totalSamples; i < inserts; i++)
                {
                    Chance chance = new Chance(Guid.NewGuid().ToString());

                    var sample = new Sample
                    {
                        Description = chance.Paragraph(3)
                    };

                    await context.Samples.AddAsync(sample, cancellationToken);

                    saveCounter++;

                    if (saveCounter == 100)
                    {
                        Log.Debug($"Saving {saveCounter} samples.");
                        await context.SaveChangesAsync(cancellationToken);
                        saveCounter = 0;
                    }
                }

                if (saveCounter > 0)
                {
                    Log.Debug($"Saving {saveCounter} samples.");
                    await context.SaveChangesAsync(cancellationToken);
                    saveCounter = 0;
                }

                totalSamples = await context.Samples.CountAsync(cancellationToken);

                Log.Debug($"{totalSamples} samples alread saved.");
            }

            Log.Debug("Samples data seed completed.");
        }
        internal static async Task SeedProfessions(this IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var total = await context.Professions.CountAsync(cancellationToken);

            var professions = new List<Profession>();

            professions.Add(new Profession { Order = 1,  Name = "Unemployed",       Default = true,  Description = "No trades until employed." });
            professions.Add(new Profession { Order = 2,  Name = "Farmer",           Default = false, Description = "Trades crops and natural foods." });
            professions.Add(new Profession { Order = 3,  Name = "Fisherman",        Default = false, Description = "Trades campfires and fishing items." });
            professions.Add(new Profession { Order = 4,  Name = "Shepherd",         Default = false, Description = "Trades shears, wool, dyes, paintings and beds." });
            professions.Add(new Profession { Order = 5,  Name = "Fletcher",         Default = false, Description = "Trades bows, crossbows, all types of arrows (except luck) and archery ingredients." });
            professions.Add(new Profession { Order = 6,  Name = "Cleric",           Default = false, Description = "Trades magic items like ender pearls, redstone dust, and enchanting or potions ingredients." });
            professions.Add(new Profession { Order = 7,  Name = "Weaponsmith",      Default = false, Description = "Trades minerals, bells and enchanted melee weapons." });
            professions.Add(new Profession { Order = 8,  Name = "Armorer",          Default = false, Description = "Trades foundry items and sells chain, iron and enchanted diamond armor tiers." });
            professions.Add(new Profession { Order = 9,  Name = "Toolsmith",        Default = false, Description = "Trades minerals, bells and harvest tools." });
            professions.Add(new Profession { Order = 10, Name = "Librarian",        Default = false, Description = "Trades enchanted books, clocks, compasses, name tags, glass, ink sacs, lanterns, and book and quills." });
            professions.Add(new Profession { Order = 11, Name = "Cartographer",     Default = false, Description = "Trades banners, compasses, banner patterns, papers and various maps, including explorer maps." });
            professions.Add(new Profession { Order = 12, Name = "Leatherworker",    Default = false, Description = "Trades scutes, rabbit hide, and leather-related items." });
            professions.Add(new Profession { Order = 13, Name = "Butcher",          Default = false, Description = "Trades meats, sweet berries, rabbit stew, and dried kelp blocks." });
            professions.Add(new Profession { Order = 14, Name = "Mason",            Default = false, Description = "Trades polished stones, terracotta, clay, glazed terracotta and quartz." });
            professions.Add(new Profession { Order = 15, Name = "Nitwit",           Default = false, Description = "No trades" });

            foreach (var profession in professions.OrderBy(x=>x.Order))
            {
                await context.Professions.AddAsync(profession, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }

            total = await context.Professions.CountAsync(cancellationToken);

            Log.Debug($"{total} professions alread saved.");

            Log.Debug("Professions data seed completed.");
        }
    }
}

using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using ChanceNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
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
    }
}

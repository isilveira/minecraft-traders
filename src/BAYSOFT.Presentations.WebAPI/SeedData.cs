using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using BAYSOFT.Infrastructures.Data;
using BAYSOFT.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI
{
    public class SeedData
    {
        public static void EnsureSeedData(IConfiguration configuration)
        {
            var services = new ServiceCollection();

            services.AddMiddleware(configuration);

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IDefaultDbContext>();

                ((DefaultDbContext)context).Database.Migrate();

                EnsureSeedData(context, configuration);
            }
        }



        private static void EnsureSeedData(IDefaultDbContext context, IConfiguration configuration)
        {
            context.Seed(configuration, default(CancellationToken)).Wait();
        }
    }
}

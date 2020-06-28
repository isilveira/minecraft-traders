using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using BAYSOFT.Infrastructures.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper.Middleware;
using System;

namespace BAYSOFT.Middleware
{
    public static class Configurations
    {
        private static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDefaultDbContext, DefaultDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContexts(configuration);


            var assembly = AppDomain.CurrentDomain.Load("BAYSOFT.Core.Application");

            services.AddMediatR(assembly);

            services.AddModelWrapper()
                .AddDefaultReturnedCollectionSize(10)
                .AddMinimumReturnedCollectionSize(1)
                .AddMaximumReturnedCollectionSize(100)
                .AddQueryTermsMinimumSize(3)
                .AddSuppressedTerms(new string[] { "the" });

            // YOUR CODE GOES HERE
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            //app.UseAuthentication();
            //app.UseAuthorization();
            // YOUR CODE GOES HERE
            return app;
        }
    }
}

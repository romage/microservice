using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        { 
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }

        private static void SeedData(AppDbContext context, bool isProduction)
        {
            if(isProduction)
            {
                Console.WriteLine("trying to apply migrations...");
                try
                {
                    context.Database.Migrate();
                } catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if(!context.Platforms.Any())
            {
                Console.WriteLine("seeding data...");
                context.Platforms.AddRange(
                    new Platform{  Name="Dot Net", Publisher="Microsoft", Cost="Free" },
                    new Platform{  Name="Sql Express", Publisher="Microsoft", Cost="Free" },
                    new Platform{  Name="Kubernetes", Publisher="Cloud native", Cost="Free" }
                );
                context.SaveChanges();
            }else
            {
                Console.WriteLine("already have data");
            }
        }
    }
}
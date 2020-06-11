
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstate.DAL.Data;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.DataSeeding
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var roles = new List<Role>()
            {
                new Role("User"),
                new Role("Agent")
            };

            await DbContext.ClearAndSeed(roles);

             static DbContext CreateDbContext()
            {

                var configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json");

                var configuration = configurationBuilder.Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                var dbContextOptionsBuilder = new DbContextOptionsBuilder()
                    .UseSqlServer(connectionString);
                var dbContextOptions = dbContextOptionsBuilder.Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}

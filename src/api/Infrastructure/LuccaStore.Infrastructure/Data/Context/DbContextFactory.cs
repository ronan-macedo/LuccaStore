using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.Data.Context
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("datasettings.json")
                .Build();

            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new();
            optionBuilder.UseNpgsql(configuration.GetConnectionString("Postgres"));
            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}

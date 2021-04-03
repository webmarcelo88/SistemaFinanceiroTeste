using Financeiro.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Financeiro.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinanceiroContext>
    {
        public FinanceiroContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<FinanceiroContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new FinanceiroContext(builder.Options);
        }
    }
}

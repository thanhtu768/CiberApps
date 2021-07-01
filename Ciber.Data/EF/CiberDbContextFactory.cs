using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ciber.Data.EF
{
    public class CiberDbContextFactory : IDesignTimeDbContextFactory<CiberDbContext>
    {
        public CiberDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("CiberDb");
            var optionBuilder = new DbContextOptionsBuilder<CiberDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new CiberDbContext(optionBuilder.Options);
        }
    }
}

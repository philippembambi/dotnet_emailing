using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace First.EmailReminder.Infrastructure.Persistence
{
    public class FirstDbContextFactory : IDesignTimeDbContextFactory<FirstDbContext>
    {
        public FirstDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? "Host=localhost;Port=5432;Database=first_email_reminder_db;Username=costa;Password=Costa";

            var optionsBuilder = new DbContextOptionsBuilder<FirstDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new FirstDbContext(optionsBuilder.Options);
        }

    }
}
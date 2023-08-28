using Blood_Bank_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management.Context
{
    public class BloodBankManagementContext : DbContext
    {
        private readonly DbContextOptions _options;

        public BloodBankManagementContext(DbContextOptions<BloodBankManagementContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from the configuration
            var connectionString = configuration.GetConnectionString("BBM");

            optionsBuilder.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly("BloodBankManagement"));
        }

        public DbSet<BloodBank> BloodBank { get; set; }
    }
}

using BalanceFlow.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BalanceFlow.Infrastracture.Connections
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<CashEntryEntity> CashEntryEntity { get; set; }
        public DbSet<DailyBalanceEntity> DailyBalanceEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataModelConfiguration.ConfigureModels(modelBuilder);
        }
    }
}
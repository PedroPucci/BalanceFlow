using BalanceFlow.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BalanceFlow.Infrastracture.Connections
{
    public static class DataModelConfiguration
    {
        public static void ConfigureModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashEntryEntity>(entity =>
            {
                entity.ToTable("transactions");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                      .IsRequired();

                entity.Property(e => e.Type)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.Property(e => e.Amount)
                      .IsRequired()
                      .HasColumnType("numeric(14,2)");

                entity.Property(e => e.TransactionDate)
                      .IsRequired();

                entity.Property(e => e.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(e => e.DailyBalance)
                      .WithMany(b => b.CashEntries)
                      .HasForeignKey(e => e.DailyBalanceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DailyBalanceEntity>(entity =>
            {
                entity.ToTable("daily_balances");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.BalanceDate)
                      .IsUnique();

                entity.Property(e => e.BalanceDate)
                      .IsRequired();

                entity.Property(e => e.TotalCredit)
                      .IsRequired()
                      .HasDefaultValue(0)
                      .HasColumnType("numeric(14,2)");

                entity.Property(e => e.TotalDebit)
                      .IsRequired()
                      .HasDefaultValue(0)
                      .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FinalBalance)
                      .IsRequired()
                      .HasColumnType("numeric(14,2)");

                entity.Property(e => e.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
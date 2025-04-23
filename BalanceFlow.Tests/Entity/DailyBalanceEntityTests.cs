using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Tests.Entity
{
    public class DailyBalanceEntityTests
    {
        [Fact]
        public void Should_Create_DailyBalance_With_Valid_Values()
        {
            // Arrange
            var date = new DateTime(2025, 4, 23);
            var credit = 500.00m;
            var debit = 300.00m;
            var final = 200.00m;
            var createdAt = DateTime.UtcNow;

            // Act
            var balance = new DailyBalanceEntity
            {
                BalanceDate = date,
                TotalCredit = credit,
                TotalDebit = debit,
                FinalBalance = final,
                CreatedAt = createdAt
            };

            // Assert
            Assert.Equal(date, balance.BalanceDate);
            Assert.Equal(credit, balance.TotalCredit);
            Assert.Equal(debit, balance.TotalDebit);
            Assert.Equal(final, balance.FinalBalance);
            Assert.Equal(createdAt, balance.CreatedAt);
            Assert.NotNull(balance.CashEntries);
            Assert.Empty(balance.CashEntries);
        }

        [Fact]
        public void Should_Allow_Empty_CashEntries_By_Default()
        {
            // Act
            var balance = new DailyBalanceEntity();

            // Assert
            Assert.NotNull(balance.CashEntries);
            Assert.Empty(balance.CashEntries);
        }

        [Fact]
        public void Should_Add_CashEntry_To_CashEntries_Collection()
        {
            // Arrange
            var entry = new CashEntryEntity
            {
                Description = "Compra estoque",
                Amount = 150,
                Type = "debit",
                TransactionDate = DateTime.Today,
                CreatedAt = DateTime.UtcNow
            };

            var balance = new DailyBalanceEntity
            {
                BalanceDate = DateTime.Today,
                FinalBalance = 0
            };

            // Act
            balance.CashEntries.Add(entry);

            // Assert
            Assert.Single(balance.CashEntries);
            Assert.Contains(entry, balance.CashEntries);
        }

        [Fact]
        public void Should_Have_Default_Values_When_Instantiated()
        {
            // Act
            var balance = new DailyBalanceEntity();

            // Assert
            Assert.Equal(0, balance.Id);
            Assert.Equal(0, balance.TotalCredit);
            Assert.Equal(0, balance.TotalDebit);
            Assert.Equal(0, balance.FinalBalance);
            Assert.Equal(default, balance.BalanceDate);
            Assert.Equal(default, balance.CreatedAt);
        }
    }
}
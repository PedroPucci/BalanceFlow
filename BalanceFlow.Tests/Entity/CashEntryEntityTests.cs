using BalanceFlow.Domain.Entity;

namespace BalanceFlow.Tests.Entity
{
    public class CashEntryEntityTests
    {
        [Fact]
        public void Should_Create_CashEntry_With_Valid_Values()
        {
            // Arrange
            var description = "Venda de produto";
            var type = "credit";
            var amount = 200.50m;
            var transactionDate = new DateTime(2025, 4, 23);
            var createdAt = DateTime.UtcNow;
            var dailyBalanceId = 1;

            // Act
            var entry = new CashEntryEntity
            {
                Description = description,
                Type = type,
                Amount = amount,
                TransactionDate = transactionDate,
                CreatedAt = createdAt,
                DailyBalanceId = dailyBalanceId
            };

            // Assert
            Assert.Equal(description, entry.Description);
            Assert.Equal(type, entry.Type);
            Assert.Equal(amount, entry.Amount);
            Assert.Equal(transactionDate, entry.TransactionDate);
            Assert.Equal(createdAt, entry.CreatedAt);
            Assert.Equal(dailyBalanceId, entry.DailyBalanceId);
            Assert.Null(entry.DailyBalance);
        }

        [Fact]
        public void Should_Allow_Empty_Description_And_Type()
        {
            // Act
            var entry = new CashEntryEntity
            {
                Amount = 10,
                TransactionDate = DateTime.Today,
                CreatedAt = DateTime.UtcNow
            };

            // Assert
            Assert.Null(entry.Description);
            Assert.Null(entry.Type);
        }

        [Fact]
        public void Should_Have_Default_Values_For_New_Instance()
        {
            // Act
            var entry = new CashEntryEntity();

            // Assert
            Assert.Equal(0, entry.Id);
            Assert.Equal(0, entry.Amount);
            Assert.Equal(default, entry.TransactionDate);
            Assert.Equal(default, entry.CreatedAt);
            Assert.Equal(0, entry.DailyBalanceId);
        }
    }
}
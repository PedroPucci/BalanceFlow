using System.Text.Json.Serialization;

namespace BalanceFlow.Domain.Entity
{
    public class CashEntryEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }

        
        public int DailyBalanceId { get; set; }
        [JsonIgnore]
        public DailyBalanceEntity? DailyBalance { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace BalanceFlow.Domain.Entity
{
    public class DailyBalanceEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime BalanceDate { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal FinalBalance { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public ICollection<CashEntryEntity> CashEntries { get; set; } = new List<CashEntryEntity>();
    }
}
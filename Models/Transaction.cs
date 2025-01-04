namespace Cashy.Models
{
    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string labels { get; set; } = string.Empty;

    }
}

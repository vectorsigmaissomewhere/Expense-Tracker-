using SQLite;

namespace Cashy.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; } // Foreign key to User

        public string Type { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Labels { get; set; } = string.Empty;
    }
}


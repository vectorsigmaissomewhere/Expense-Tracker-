using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Cashy.Models
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [AutoIncrement]
        public int SessionID { get; set; } 
        [StringLength(50)]
        public string Key { get; set; } = string.Empty;
        [StringLength(50)]
        public string Value { get; set; } = string.Empty;
        [StringLength(50)]
        public string LastUpdated { get; set; } = string.Empty; // Store as string
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashy.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Type { get; set; } // Credit or Debt
        public List<string> Tags { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public List<string> Labels { get; set; }
        public int UserId { get; set; }
    }

}

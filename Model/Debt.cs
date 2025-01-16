using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashy.Model
{
    public class Debt
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; } // True for paid, False for unpaid
        public int UserId { get; set; }
    }

}

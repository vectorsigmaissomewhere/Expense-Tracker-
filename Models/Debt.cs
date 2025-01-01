using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashy.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Amount { get; set; } 
    }
}

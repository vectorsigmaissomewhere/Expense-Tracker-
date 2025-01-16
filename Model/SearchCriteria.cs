using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashy.Model
{
    public class SearchCriteria
    {
        public string Type { get; set; }
        public string TagsInput { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
    }
}

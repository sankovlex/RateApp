using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Models.OptionalParams
{
    public class CurrencyFilter
    {
        public string Name { get; set; }

        public string OrderBy { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Models.OptionalParams
{
    public class Paging
    {
        public int Take { get; set; } = 50;
        public int Skip { get; set; } = 0;
    }
}

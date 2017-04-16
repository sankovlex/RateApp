using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Models.Domain
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        public DateTime DateCreate { get; set; }
    }
}

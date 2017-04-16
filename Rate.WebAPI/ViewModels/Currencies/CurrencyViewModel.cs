using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rate.WebAPI.ViewModels.Currencies
{
    public class CurrencyViewModel
    {
        public string Name { get; set; }

        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        public string DateCreate { get; set; }
    }
}

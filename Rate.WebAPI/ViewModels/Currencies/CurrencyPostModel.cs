using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rate.WebAPI.ViewModels.Currencies
{
    public class CurrencyPostModel
    {
        [Required]
        [MaxLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
    }
}

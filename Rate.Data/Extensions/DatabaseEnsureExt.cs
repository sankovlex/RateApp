using Rate.Data.Core;
using Rate.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Data.Extensions
{
    public static class DatabaseEnsureExt
    {
        public static void Seed(this EfContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Currencies.Any())
            {
                var currencies = new[] {
                    new Currency{ Name = "usd", SellingPrice = 56.1m, PurchasePrice = 56.8m, DateCreate = new DateTime(2017, 3, 15)},
                    new Currency{ Name = "eur", SellingPrice = 63.4m, PurchasePrice = 63.6m, DateCreate = new DateTime(2017, 3, 17)},
                    new Currency{ Name = "gbr", SellingPrice = 70.7m, PurchasePrice = 70.8m, DateCreate = new DateTime(2017, 3, 19)},
                    new Currency{ Name = "eur", SellingPrice = 64.9m, PurchasePrice = 65.2m, DateCreate = new DateTime(2017, 3, 21)},
                    new Currency{ Name = "gbr", SellingPrice = 70.8m, PurchasePrice = 70.9m, DateCreate = new DateTime(2017, 3, 23)},
                    new Currency{ Name = "usd", SellingPrice = 57.3m, PurchasePrice = 57.7m, DateCreate = new DateTime(2017, 4, 4)},
                    new Currency{ Name = "usd", SellingPrice = 58.1m, PurchasePrice = 58.3m, DateCreate = new DateTime(2017, 4, 8)},
                };

                context.AddRange(currencies);
                context.SaveChanges();
            }
        }
    }
}

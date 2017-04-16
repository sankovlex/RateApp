using Rate.ConsoleApp.RateServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                #region CONSOLE
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("void");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" AddCurrency(");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Currency ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("currency)");
                Console.ResetColor();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("2: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Currency");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[] GetCurrencies(");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Paging ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("paging, ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("CurrencyFilter ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("filter)");
                Console.ResetColor();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("3: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Currency");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" GetLastCurrency(");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("string ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("name)");
                Console.ResetColor();

                Console.WriteLine();

                Console.Write("Your choice: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                var choice = int.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.WriteLine(); 
                #endregion

                switch (choice)
                {
                    case 1:
                        AddCurrency();
                        break;
                    case 2:
                        GetCurrencies();
                        break;
                    case 3:
                        GetLastCurrency();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddCurrency()
        {
            var currency = new Currency();

            #region CONSOLE
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("new ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Currency");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tName");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" string");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" maxLength(3) = ");
            currency.Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tSelling price");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" decimal = ");
            Console.ForegroundColor = ConsoleColor.White;
            currency.SellingPrice = decimal.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tPurchase price");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" decimal = ");
            Console.ForegroundColor = ConsoleColor.White;
            currency.PurchasePrice = decimal.Parse(Console.ReadLine()); 
            #endregion

            using (var client = new RateServiceClient())
            {
                Task.Run(async () =>
                {
                    await client.AddCurrencyAsync(currency);

                }).GetAwaiter().GetResult();
            }
        }

        static void GetCurrencies()
        {
            var currencies = new List<Currency>();

            var paging = new Paging();

            #region paging set
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("new ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Paging");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tTake");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" int");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                paging.Take = int.Parse(Console.ReadLine());
            }
            catch { }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tSkip");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" int");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                paging.Skip = int.Parse(Console.ReadLine());
            }
            catch { } 
            #endregion

            var filter = new CurrencyFilter();

            #region filter set
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("new ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("CurrencyFilter");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tName");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" string(nullable)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    filter.Name = name;
            }
            catch { }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tOrderBy");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" string(nullable)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                var orderBy = Console.ReadLine();
                if (!string.IsNullOrEmpty(orderBy))
                    filter.OrderBy = orderBy;
            }
            catch { }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tStartDate");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" DateTime(nullable)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" format:yyyy-MM-dd");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                filter.StartDate = DateTime.Parse(Console.ReadLine());
            }
            catch { }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEndDate");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" DateTime(nullable)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" format:yyyy-MM-dd");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            try
            {
                filter.EndDate = DateTime.Parse(Console.ReadLine());
            }
            catch { } 
            #endregion


            using (var client = new RateServiceClient())
            {
                Task.Run(async () =>
                {
                    var result = await client.GetCurrenciesAsync(paging, filter);

                    currencies = result.ToList();

                }).GetAwaiter().GetResult();
            }

            foreach (var item in currencies)
            {
                Console.WriteLine("Currency name: {0}\t| Selling price: {1}\t| Purchase price: {2}\t| Date: {3}", item.Name, item.SellingPrice, item.PurchasePrice, item.DateCreate);
            }
        }

        static void GetLastCurrency()
        {
            Console.Write("Enter name currency: ");
            string name = Console.ReadLine();

            var result = new Currency();

            using (var client = new RateServiceClient())
            {
                Task.Run(async () =>
                {
                    result = await client.GetLastCurrencyAsync(name);

                }).GetAwaiter().GetResult();
            }

            Console.WriteLine("Last currency {0}: Selling price {1}, Purchase price {2}, Date {3}", result.Name, result.SellingPrice, result.PurchasePrice, result.DateCreate);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rate.Data.Core.Repository;
using Rate.Models.Domain;
using Rate.Models.OptionalParams;
using Rate.Services.Core;
using Rate.Services.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rate.Tests.Services
{
    [TestClass]
    public class RateServiceTest
    {
        private Mock<IRepository<Currency>> currencyRepository;
        private IRateService rateService;

        public RateServiceTest()
        {
            currencyRepository = new Mock<IRepository<Currency>>();
            rateService = new DefaultRateService(currencyRepository.Object);
        }

        [TestMethod]
        public void Can_Add_Currency()
        {
            // arrage
            currencyRepository.Setup(x => x.CreateAsync(It.IsAny<Currency>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // act
            var taskResult = rateService.AddCurrencyAsync(new Currency { Name = "EUR", PurchasePrice = 100, SellingPrice = 200 });

            // assert
            Assert.IsTrue(taskResult.IsCompleted);
            currencyRepository.Verify();
        }

        [TestMethod]
        public void Can_Add_Currency_Fail()
        {
            // arrage
            currencyRepository.Setup(x => x.CreateAsync(It.IsAny<Currency>()))
                .Returns(Task.FromException(new Exception()))
                .Verifiable();

            // act
            var taskResult = rateService.AddCurrencyAsync(new Currency { Name = "EUR", PurchasePrice = 100, SellingPrice = 200 });

            // assert
            Assert.IsTrue(taskResult.IsFaulted);
            currencyRepository.Verify();
        }

        [TestMethod]
        public void Get_Currencies()
        {
            // arrage
            var paging = new Paging();
            var filter = new CurrencyFilter { StartDate = new DateTime(2016, 1, 1), EndDate = new DateTime(2016, 4, 2) };

            var currencies = new[] {
                new Currency{ Id = 1, Name = "EUR", PurchasePrice = 10, SellingPrice = 11, DateCreate = new DateTime(2015, 1, 1)},
                new Currency{ Id = 2, Name = "USD", PurchasePrice = 9, SellingPrice = 10, DateCreate = new DateTime(2016, 2, 1)},
                new Currency{ Id = 3, Name = "USD", PurchasePrice = 9.1m, SellingPrice = 10.2m, DateCreate = new DateTime(2016, 3, 1)},
                new Currency{ Id = 4, Name = "EUR", PurchasePrice = 10.3m, SellingPrice = 11.6m, DateCreate = new DateTime(2016, 4, 1)},
                new Currency{ Id = 5, Name = "EUR", PurchasePrice = 9.9m, SellingPrice = 10.9m, DateCreate = new DateTime(2016, 5, 1)}
            }.AsQueryable();

            Func<IQueryable<Currency>, IQueryable<Currency>> query = q =>
            {
                if (filter?.Name != null)
                    q = q.Where(x => x.Name.Contains(filter.Name));

                if (filter?.StartDate != null)
                    q = q.Where(x => x.DateCreate >= filter.StartDate);

                if (filter?.EndDate != null)
                    q = q.Where(x => x.DateCreate <= filter.EndDate);

                if (filter?.OrderBy != null)
                    q = q.OrderBy(x => x.PropValue<Currency>(filter.OrderBy));

                q = q.Skip(paging.Skip).Take(paging.Take);

                return q;
            };

            var resultCurrencies = query(currencies).ToList();

            currencyRepository.Setup(x => x.GetAsync(It.IsAny<Func<IQueryable<Currency>, IQueryable<Currency>>>()))
                .ReturnsAsync(resultCurrencies);

            // act
            var taskResult = rateService.GetCurrenciesAsync(paging, filter);

            // assert
            Assert.IsTrue(taskResult.IsCompleted);
            var model = taskResult.Result;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<Currency>));
            Assert.AreEqual(resultCurrencies.Count(), model.Count());
        }

        [TestMethod]
        public void Get_Currencies_ArgumentExeption()
        {
            // arrage
            var paging = new Paging();
            var filter = new CurrencyFilter() { StartDate = new DateTime(2017, 4, 2), EndDate = new DateTime(2017, 4, 1) };

            // act & assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => rateService.GetCurrenciesAsync(paging, filter));
        }
    }
}

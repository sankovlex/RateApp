using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rate.WebAPI.Controllers;
using Moq;
using Rate.Services.Rates;
using AutoMapper;
using Rate.WebAPI.Mappings;
using Rate.Models.OptionalParams;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using Rate.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Rate.WebAPI.ViewModels.Currencies;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rate.Tests.API
{
    [TestClass]
    public class CurrencyControllerTest
    {
        private CurrencyController controller;
        private IMapper mapper;
        private Mock<IRateService> rateService;

        public CurrencyControllerTest()
        {
            rateService = new Mock<IRateService>();

            //configurate mapper (simplify testing, mapper test isolated)
            var mapperConfiguration = new MapperConfiguration(option =>
            {
                option.AddProfile<DomainToViewProfile>();
                option.AddProfile<ViewToDomainProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();

            controller = new CurrencyController(mapper, rateService.Object);
        }

        [TestMethod]
        public async Task Get_Ok()
        {
            // arrage
            var currencies = new[] {
                new Currency{ Name = "usd", PurchasePrice = 10m,SellingPrice = 11m, DateCreate = DateTime.Now },
                new Currency{ Name = "eur", PurchasePrice = 11m,SellingPrice = 12m, DateCreate = DateTime.Now },
                new Currency{ Name = "gbr", PurchasePrice = 10m,SellingPrice = 13m, DateCreate = DateTime.Now },
            }.AsEnumerable();

            rateService.Setup(x => x.GetCurrenciesAsync(It.IsAny<Paging>(), It.IsAny<CurrencyFilter>()))
                .Returns(Task.FromResult(currencies));

            // act
            var action = await controller.Get(new Paging(), new CurrencyFilter());

            // assert
            Assert.IsInstanceOfType(action, typeof(OkObjectResult));
            var result = action as OkObjectResult;
            Assert.IsInstanceOfType(result.Value, typeof(List<CurrencyViewModel>));
            var model = result.Value as List<CurrencyViewModel>;
            Assert.AreEqual(model.Count(), currencies.Count());
        }

        [TestMethod]
        public async Task Get_204()
        {
            // arrage
            rateService.Setup(x => x.GetCurrenciesAsync(It.IsAny<Paging>(), It.IsAny<CurrencyFilter>()))
                .Returns(Task.FromResult(new List<Currency>().AsEnumerable()));

            // act
            var action = await controller.Get(new Paging(), new CurrencyFilter());

            // assert
            Assert.IsInstanceOfType(action, typeof(StatusCodeResult));
            var result = action as StatusCodeResult;
            Assert.AreEqual(result.StatusCode, 204);
        }

        [TestMethod]
        public async Task Get_400()
        {
            // arrage
            rateService.Setup(x => x.GetCurrenciesAsync(It.IsAny<Paging>(), It.IsAny<CurrencyFilter>()))
                .Throws<ArgumentException>();

            // act
            var action = await controller.Get(new Paging(), new CurrencyFilter());

            // assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));
            var result = action as BadRequestObjectResult;
            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public async Task Get_Last_Ok()
        {
            // arrage
            var currency = new Currency { Name = "usd", PurchasePrice = 10, SellingPrice = 20, DateCreate = DateTime.Now };

            rateService.Setup(x => x.GetLastCurrencyAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(currency));

            // act
            var action = await controller.Get("usd");

            // assert
            Assert.IsInstanceOfType(action, typeof(OkObjectResult));
            var result = action as OkObjectResult;
            Assert.AreEqual(result.StatusCode, 200);
            var model = result.Value as CurrencyViewModel;
            Assert.IsFalse(model == null);
            Assert.AreEqual(model.Name, currency.Name);
        }

        [TestMethod]
        public async Task Get_Last_204()
        {
            // arrage
            var currency = new Currency { Name = "usd", PurchasePrice = 10, SellingPrice = 20, DateCreate = DateTime.Now };

            rateService.Setup(x => x.GetLastCurrencyAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(null as Currency));

            // act
            var action = await controller.Get("usd");

            // assert
            Assert.IsInstanceOfType(action, typeof(StatusCodeResult));
            var result = action as StatusCodeResult;
            Assert.AreEqual(result.StatusCode, 204);
        }

        [TestMethod]
        public async Task Post_Ok()
        {
            // arrage
            var currency = new CurrencyPostModel { Name = "usd", PurchasePrice = 10, SellingPrice = 20 };

            rateService.Setup(x => x.AddCurrencyAsync(It.IsAny<Currency>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // act
            var action = await controller.Post(currency);

            // assert
            Assert.IsInstanceOfType(action, typeof(OkResult));
            var result = action as OkResult;
            Assert.AreEqual(result.StatusCode, 200);
            rateService.Verify();
        }

        [TestMethod]
        public async Task Post_400_ValidModel()
        {
            // arrage
            controller.ModelState.AddModelError("error", "some error");

            // act
            var action = await controller.Post(It.IsAny<CurrencyPostModel>());

            // assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));
            var result = action as BadRequestObjectResult;
            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public async Task Post_400_Exception()
        {
            // arrage
            var currency = new CurrencyPostModel { Name = "usd", PurchasePrice = 10, SellingPrice = 20 };

            rateService.Setup(x => x.AddCurrencyAsync(It.IsAny<Currency>()))
                .Throws<Exception>()
                .Verifiable();

            // act
            var action = await controller.Post(currency);

            // assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));
            var result = action as BadRequestObjectResult;
            Assert.AreEqual(result.StatusCode, 400);
        }
    }
}

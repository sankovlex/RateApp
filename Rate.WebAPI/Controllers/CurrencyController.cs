using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rate.Services.Rates;
using Rate.Models.OptionalParams;
using AutoMapper;
using Rate.Models.Domain;
using Rate.WebAPI.ViewModels.Currencies;
using Rate.WebAPI.ViewModels.Errors;

namespace Rate.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private IRateService rateService;
        private IMapper mapper;

        public CurrencyController(IMapper mapper, IRateService rateService)
        {
            this.rateService = rateService;
            this.mapper = mapper;
        }

        // GET: api/Currency
        /// <summary>
        /// GET: Get currencies statistic
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(Paging paging, CurrencyFilter filter)
        {
            try
            {
                var currencies = await rateService.GetCurrenciesAsync(paging, filter);

                if (!currencies.Any())
                    return StatusCode(204);

                var result = mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyViewModel>>(currencies);

                return Ok(result);
            }
            // If start date > end date
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        // GET: api/Currency/usd
        /// <summary>
        /// GET: Get last currency by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var currency = await rateService.GetLastCurrencyAsync(name);

            if (currency == null)
                return StatusCode(204);

            var result = mapper.Map<Currency, CurrencyViewModel>(currency);

            return Ok(result);
        }

        // POST: api/Currency
        /// <summary>
        /// POST: Add currency in repository
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CurrencyPostModel postModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var currency = mapper.Map<CurrencyPostModel, Currency>(postModel);

                await rateService.AddCurrencyAsync(currency);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}

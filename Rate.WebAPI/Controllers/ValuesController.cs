using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rate.Services.Rates;
using Rate.Models.Domain;
using Rate.Models.OptionalParams;
using Rate.WebAPI.ViewModels.Errors;

namespace Rate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRateService rateService;

        public ValuesController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(Paging paging, CurrencyFilter filter)
        {
            try
            {
                var currencies = await rateService.GetCurrenciesAsync(paging, filter);
                return Ok(currencies);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message});
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Currency currency)
        {
            try
            {
                await rateService.AddCurrencyAsync(currency);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message});
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

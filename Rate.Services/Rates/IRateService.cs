using Rate.Models.Domain;
using Rate.Models.OptionalParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Services.Rates
{
    [ServiceContract]
    public interface IRateService
    {
        /// <summary>
        /// Add currency in repository
        /// </summary>
        /// <param name="currency"> Adding currency </param>
        [OperationContract]
        void AddCurrency(Currency currency);
        /// <summary>
        /// ASYNC: Add currency in repository
        /// </summary>
        /// <param name="currency"> Adding currency </param>
        /// <returns></returns>
        Task AddCurrencyAsync(Currency currency);

        /// <summary>
        /// Get currency by filter
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Currency> GetCurrencies(Paging paging, CurrencyFilter filter);
        /// <summary>
        /// ASYNC: Get currency by filter
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Currency>> GetCurrenciesAsync(Paging paging, CurrencyFilter filter);

        /// <summary>
        /// Get current currency
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Currency GetLastCurrency(string name);
        /// <summary>
        /// ASYNC: Get current currency
        /// </summary>
        /// <returns></returns>
        Task<Currency> GetLastCurrencyAsync(string name);
    }
}

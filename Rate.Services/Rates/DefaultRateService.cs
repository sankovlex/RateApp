using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rate.Models.Domain;
using Rate.Models.OptionalParams;
using Rate.Data.Core.Repository;
using Rate.Services.Core;

namespace Rate.Services.Rates
{
    public class DefaultRateService : IRateService
    {
        private IRepository<Currency> currencyRepository;

        public DefaultRateService(IRepository<Currency> currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public void AddCurrency(Currency currency)
        {
            try
            {
                currencyRepository.CreateAsync(currency);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddCurrencyAsync(Currency currency)
        {
            try
            {
                await currencyRepository.CreateAsync(currency);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Currency> GetCurrencies(Paging paging, CurrencyFilter filter)
        {
            if (filter != null && filter.StartDate != null && filter.EndDate != null && filter.StartDate > filter.EndDate)
                throw new ArgumentException("Start date must be less than end date");

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

                if (paging?.Take > 0)
                    q = q.Skip(paging.Skip).Take(paging.Take);

                return q;
            };

            return currencyRepository.Get(query);
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(Paging paging, CurrencyFilter filter)
        {
            if (filter != null && filter.StartDate != null && filter.EndDate != null && filter.StartDate > filter.EndDate)
                throw new ArgumentException("Start date must be less than end date");

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

                if (paging?.Take > 0)
                    q = q.Skip(paging.Skip).Take(paging.Take);

                return q;
            };

            return await currencyRepository.GetAsync(query);
        }

        public Currency GetLastCurrency(string name)
        {
            return currencyRepository.Find(x => x.Name == name, q => q.OrderByDescending(x => x.DateCreate));
        }

        public async Task<Currency> GetLastCurrencyAsync(string name)
        {
            return await currencyRepository.FindAsync(x => x.Name == name, q => q.OrderByDescending(x => x.DateCreate));
        }
    }
}

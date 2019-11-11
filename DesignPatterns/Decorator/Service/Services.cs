using System;
using System.Collections.Generic;

namespace Decorator
{
    public interface ICurrencyService
    {
        decimal GetExchangeRate(string currency);
    }

    class CurrencyService : ICurrencyService
    {
        public decimal GetExchangeRate(string currency)
        {
            Console.WriteLine("Collect data from database, webservice, etc.");

            if (currency == "EUR") return 305;
            else if (currency == "USD") return 289;
            else return 0;
        }
    }

    class CachedCurrencyService : ICurrencyService
    {
        private readonly ICurrencyService currencyService;

        private readonly Dictionary<string, decimal> cache = new Dictionary<string, decimal>();

        public CachedCurrencyService(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public decimal GetExchangeRate(string currency)
        {
            if (cache.ContainsKey(currency))
            {
                Console.WriteLine("Get value from cache.");
                return cache[currency];
            }
            else
            {
                Console.WriteLine("Get value from service.");
                decimal exchangeRate = this.currencyService.GetExchangeRate(currency);
                cache.Add(currency, exchangeRate);
                return exchangeRate;
            }
        }
    }

    class LoggedCurrencyService : ICurrencyService
    {
        private readonly ICurrencyService currencyService;

        public LoggedCurrencyService(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public decimal GetExchangeRate(string currency)
        {
            Console.WriteLine($"{Environment.UserName} ask for the exchange rate of {currency}");
            return this.currencyService.GetExchangeRate(currency);
        }
    }
}

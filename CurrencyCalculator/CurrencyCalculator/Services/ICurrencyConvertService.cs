using System.Collections.Generic;

namespace CurrencyCalculator
{
    public interface ICurrencyConvertService
    {
        string GetCurrencyExchangeRates(string currencyCode);
        List<string> GetCurrencyList();
    }
}
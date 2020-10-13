using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace CurrencyCalculator
{
    public class CurrencyConvertService : ICurrencyConvertService
    {
        public string GetCurrencyExchangeRates(string currencyCode)
        {
            var url = "https://api.exchangerate-api.com/v4/latest/";

            string jsonString;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}/{currencyCode}");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }

        public List<string> GetCurrencyList()
        {
            try
            {
                var currenciesJson = GetCurrencyExchangeRates("GBP");

                dynamic data = JsonConvert.DeserializeObject(currenciesJson);

                var result = new RouteValueDictionary(data.rates);

                throw new Exception("Ran of of time trying to work this out!");

                return ((Dictionary<string, decimal>)data.rates).Select(x => x.Key).ToList();
            }
            catch (Exception e)
            {
                return new List<string>()
                {
                    "GBP", "USD", "EUR"
                };
            }
        }
    }
}

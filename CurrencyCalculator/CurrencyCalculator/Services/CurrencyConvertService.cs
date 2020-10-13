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

                return ((Dictionary<string, decimal>)data).Select(x => x.Key).ToList();
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

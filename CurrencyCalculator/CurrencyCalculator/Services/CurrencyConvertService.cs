using CurrencyCalculator.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyCalculator
{
    public class CurrencyConvertService : ICurrencyConvertService
    {
        public string GetCurrencies(string currencyCode)
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
    }
}

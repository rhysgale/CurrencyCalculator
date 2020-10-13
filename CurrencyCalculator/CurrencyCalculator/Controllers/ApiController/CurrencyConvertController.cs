using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyCalculator.Controllers.ApiController
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyConvertController : ControllerBase
    {
        private readonly ICurrencyConvertService _service;

        public CurrencyConvertController(ICurrencyConvertService service)
        {
            _service = service;
        }

        [HttpGet("GetCurrencyRates/{currencyCode}")]
        public string GetCurrencyRates(string currencyCode)
        {
            return _service.GetCurrencies(currencyCode);
        }
    }
}

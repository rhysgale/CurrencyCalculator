using CurrencyCalculator;
using NUnit.Framework;

namespace CurrencyConverter.UnitTests
{
    public class Tests
    {
        private ICurrencyConvertService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CurrencyConvertService();
        }

        [Test]
        public void CurrencyConvertService_ReturnsValidResponseForGetCurrencies()
        {
            var retVal = _service.GetCurrencies("GBP");

            Assert.IsNotNull(retVal);
        }
    }
}
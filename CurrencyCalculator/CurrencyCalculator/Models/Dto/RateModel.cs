using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.Models.Dto
{
    public class RateModel
    {
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}

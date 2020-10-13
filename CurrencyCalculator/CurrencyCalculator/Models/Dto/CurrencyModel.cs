using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.Models.Dto
{
    public class CurrencyModel
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time_Last_Updated { get; set; }

        public List<RateModel> Rates { get; set; }
    }
}

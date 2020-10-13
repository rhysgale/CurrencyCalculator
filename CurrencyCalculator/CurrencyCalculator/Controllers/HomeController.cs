using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CurrencyCalculator.Models;

namespace CurrencyCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyConvertService _service;

        public HomeController(ILogger<HomeController> logger, ICurrencyConvertService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel() 
            {
                Currencies = _service.GetCurrencyList()
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

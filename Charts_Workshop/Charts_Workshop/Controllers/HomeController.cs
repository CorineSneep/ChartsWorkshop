using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Charts_Workshop.Models;
using Charts_Workshop.ViewModels;

namespace Charts_Workshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Random rnd = new Random();
        
            var lstModel = new List<CityChartViewModel>();
            lstModel.Add( new CityChartViewModel
            {  
                name = "Amsterdam",  
                price = rnd.Next( 10 )  
            } );
            lstModel.Add(new CityChartViewModel
            {
                name = "Arnhem",
                price = rnd.Next(10)
            });
            lstModel.Add(new CityChartViewModel
            {
                name = "Nijmegen",
                price = rnd.Next(10)
            });
            lstModel.Add(new CityChartViewModel
            {
                name = "Amersfoort",
                price = rnd.Next(10)
            });
            lstModel.Add(new CityChartViewModel
            {
                name = "Utrecht",
                price = rnd.Next(10)
            });
           
            return View(lstModel);
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tilcard.Models;
using Tilecard.Models;

namespace Tilecard.Controllers
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
            ViewBag.CardSource1List = CardDemo.CardDemoData.Take(1).ToList();
            ViewBag.CardSource2List = CardDemo.CardDemoData.Take(2).ToList();
            ViewBag.CardSource3List = CardDemo.CardDemoData.Take(3).ToList();
            ViewBag.CardSource4List = CardDemo.CardDemoData.Take(4).ToList();
            ViewBag.CardSource5List = CardDemo.CardDemoData.Take(5).ToList();
            ViewBag.CardSource6List = CardDemo.CardDemoData.Take(6).ToList();
            return View();
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

        public IActionResult Card()
        {
            ViewBag.CardSource1List = CardDemo.CardDemoData.Take(1).ToList();
            ViewBag.CardSource2List = CardDemo.CardDemoData.Take(2).ToList();
            ViewBag.CardSource3List = CardDemo.CardDemoData.Take(3).ToList();
            ViewBag.CardSource4List = CardDemo.CardDemoData.Take(4).ToList();
            ViewBag.CardSource5List = CardDemo.CardDemoData.Take(5).ToList();
            ViewBag.CardSource6List = CardDemo.CardDemoData.Take(6).ToList();
            return View();
        }


    }
}

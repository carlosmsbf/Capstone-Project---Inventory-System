using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCL_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Method Get to show the Home View.
        public IActionResult Index()
        {
            return View();
        }

    }
}

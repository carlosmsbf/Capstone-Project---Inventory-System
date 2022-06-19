using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RCL_Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;


namespace RCL_Inventory.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<AboutUsController> _logger;


        public AboutUsController(ILogger<AboutUsController> logger)
        {
            _logger = logger;
        }


        // Method Get to show the About Us View.
        public IActionResult Index()
        {
            return View();
        }
    }
}

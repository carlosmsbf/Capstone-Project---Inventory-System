using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RCL_Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;


namespace RCL_Inventory.Controllers
{
    public class HelpController : Controller
    {
        private readonly ILogger<HelpController> _logger;


        public HelpController(ILogger<HelpController> logger)
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

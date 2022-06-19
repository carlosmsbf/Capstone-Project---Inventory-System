using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RCL_Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;


namespace RCL_Inventory.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ILogger<ContactUsController> _logger;


        public ContactUsController(ILogger<ContactUsController> logger)
        {
            _logger = logger;
        }

        // Method Get to show the Contact Us View.
        public IActionResult Index()
        {
            return View();
        }
    }
}

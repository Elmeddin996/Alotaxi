using Microsoft.AspNetCore.Mvc;

namespace Alotaxi.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult Costumer()
        {
            return View();
        }

        public IActionResult Driver()
        { 
            return View();
        }
    }
}

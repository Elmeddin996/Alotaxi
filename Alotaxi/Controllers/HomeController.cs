using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alotaxi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

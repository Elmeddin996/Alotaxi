using Alotaxi.DAL;
using Alotaxi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Alotaxi.Controllers
{
    public class AboutController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public AboutController(AlotaxiDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutPageViewModel vm = new AboutPageViewModel
            {
                Categories=_context.Categories.ToList()
            };
            return View();
        }
    }
}

using Alotaxi.DAL;
using Alotaxi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Alotaxi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public HomeController(AlotaxiDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                Settings = _context.Settings.ToList(),
                Statistics = _context.Statistics.ToList(),
                WhyUs = _context.WhyUs.Take(3).ToList(),

            };
            return View(vm);
        }
    }
}

using Alotaxi.DAL;
using Alotaxi.Helpers;
using Alotaxi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Alotaxi.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("manage")]
    public class SettingsController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public SettingsController(AlotaxiDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Settings settings = _context.Settings.FirstOrDefault();
            return View(settings);
        }

        public IActionResult Edit(int id)
        {
            Settings settings = _context.Settings.Find(id);
            if (settings == null) return StatusCode(404);

            return View(settings);
        }

        [HttpPost]
        public IActionResult Edit(Settings settings)
        {
            Settings existSettings = _context.Settings.Find(settings.Id);
            if (existSettings == null) return StatusCode(404);

            existSettings.Address= settings.Address;
            existSettings.Email= settings.Email;
            existSettings.Phone= settings.Phone;
            existSettings.PlayStore= settings.PlayStore;
            existSettings.AppStore= settings.AppStore;
            existSettings.Instagram= settings.Instagram;
            existSettings.Facebook = settings.Facebook;
            existSettings.BusinessDescription = settings.BusinessDescription;
            existSettings.BusinessTitle = settings.BusinessTitle;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

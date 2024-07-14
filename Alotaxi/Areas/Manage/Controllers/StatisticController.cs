using Alotaxi.DAL;
using Alotaxi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alotaxi.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("manage")]
    public class StatisticController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public StatisticController(AlotaxiDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Statistic statistic = _context.Statistics.FirstOrDefault();
            return View(statistic);
        }

        public IActionResult Edit(int id)
        {
            Statistic statistic = _context.Statistics.Find(id);
            if (statistic == null) return StatusCode(404);

            return View(statistic);
        }

        [HttpPost]
        public IActionResult Edit(Statistic statistic)
        {
            Statistic existStatistic = _context.Statistics.Find(statistic.Id);
            if (existStatistic == null) return StatusCode(404);

            existStatistic.RoadCount = statistic.RoadCount;
            existStatistic.CarCount = statistic.CarCount;
            existStatistic.LocationCount = statistic.LocationCount;


            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

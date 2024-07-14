using Alotaxi.DAL;
using Alotaxi.Helpers;
using Alotaxi.Models;
using Alotaxi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alotaxi.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("manage")]
    public class WhyUsController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public IWebHostEnvironment _env { get; }

        public WhyUsController(AlotaxiDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.WhyUs.AsQueryable();

            if (search != null)
                query = query.Where(x => x.Title.Contains(search));

            ViewBag.Search = search;

            return View(PaginatedList<WhyUs>.Create(query, page, 6));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(WhyUs whyUs)
        {

            whyUs.Image = FileManager.Save(_env.WebRootPath, "uploads/whyUs", whyUs.ImageFile);

            _context.WhyUs.Add(whyUs);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            WhyUs whyUs = _context.WhyUs.Find(id);

            if (whyUs == null) return View("Error");

            return View(whyUs);
        }

        [HttpPost]
        public IActionResult Edit(WhyUs whyUs)
        {
            WhyUs existWhyUs = _context.WhyUs.Find(whyUs.Id);

            if (existWhyUs == null) return View("Error");


            string oldFileName = null;
            if (whyUs.ImageFile != null)
            {
                oldFileName = existWhyUs.Image;
                existWhyUs.Image = FileManager.Save(_env.WebRootPath, "uploads/whyUs", whyUs.ImageFile);
            }

            existWhyUs.Title = whyUs.Title;
            existWhyUs.Description = whyUs.Description;

            _context.SaveChanges();

            if (oldFileName != null)
                FileManager.Delete(_env.WebRootPath, "uploads/whyUs", oldFileName);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            WhyUs whyUs = _context.WhyUs.Find(id);

            if (whyUs == null) return StatusCode(404);

            _context.WhyUs.Remove(whyUs);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/whyUs", whyUs.Image);

            return StatusCode(200);
        }
    }
}

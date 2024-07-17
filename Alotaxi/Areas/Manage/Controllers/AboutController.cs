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
    public class AboutController : Controller
    {
        private readonly AlotaxiDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(AlotaxiDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.About.AsQueryable();

            if (search != null)
                query = query.Where(x => x.BigTitle.Contains(search));

            ViewBag.Search = search;

            return View(PaginatedList<About>.Create(query, page, 6));
        }

        public IActionResult Edit(int id)
        {
            About about = _context.About.Find(id);

            if (about == null) return View("Error");

            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {

            About existAbout = _context.About.Find(about.Id);

            if (existAbout == null) return View("Error");

            if (about.BigTitle != existAbout.BigTitle && _context.About.Any(x => x.BigTitle == about.BigTitle))
            {
                ModelState.AddModelError("BigTitle", "Title is already taken");
                return View();
            }

            string oldImage = null;
            if (about.ImageFile != null)
            {
                oldImage = existAbout.Image;

                if (about.Image == null)
                {
                    about.Image = FileManager.Save(_env.WebRootPath, "uploads/about", about.ImageFile);
                    existAbout.Image = about.Image;
                }
                else
                    about.Image = FileManager.Save(_env.WebRootPath, "uploads/about", about.ImageFile);
            }
            else
            {
                about.Image = existAbout.Image;
            }

            string oldBigImage = null;
            if (about.BigImageFile != null)
            {
                oldBigImage = existAbout.BigImage;

                if (about.BigImage == null)
                {
                    about.BigImage = FileManager.Save(_env.WebRootPath, "uploads/about", about.BigImageFile);
                    existAbout.BigImage = about.BigImage;
                }
                else
                    about.BigImage = FileManager.Save(_env.WebRootPath, "uploads/about", about.BigImageFile);
            }
            else
            {
                about.BigImage = existAbout.BigImage;
            }

            existAbout.BigTitle = about.BigTitle;
            existAbout.Detail = about.Detail;
            existAbout.Title = about.Title;

            _context.SaveChanges();

            if (oldImage != null) FileManager.Delete(_env.WebRootPath, "uploads/about", oldImage);
            if (oldBigImage != null) FileManager.Delete(_env.WebRootPath, "uploads/about", oldBigImage);


            return RedirectToAction("index");
        }

    }
}

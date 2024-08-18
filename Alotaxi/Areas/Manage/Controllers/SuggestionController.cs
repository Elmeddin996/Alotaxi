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
    public class SuggestionController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public IWebHostEnvironment _env { get; }

        public SuggestionController(AlotaxiDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Suggestions.AsQueryable();


            return View(PaginatedList<Suggestion>.Create(query, page, 6));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Suggestion suggestion)
        {
            if (suggestion.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }

            suggestion.Image = FileManager.Save(_env.WebRootPath, "uploads/suggestion", suggestion.ImageFile);

            _context.Suggestions.Add(suggestion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Suggestion suggestion = _context.Suggestions.Find(id);

            if (suggestion == null) return View("Error");

            return View(suggestion);
        }

        [HttpPost]
        public IActionResult Edit(Suggestion suggestion)
        {
            Suggestion existSuggestion = _context.Suggestions.Find(suggestion.Id);

            if (existSuggestion == null) return View("Error");


            string oldFileName = null;
            if (suggestion.ImageFile != null)
            {
                oldFileName = existSuggestion.Image;
                existSuggestion.Image = FileManager.Save(_env.WebRootPath, "uploads/suggestion", suggestion.ImageFile);
            }

            existSuggestion.Name = suggestion.Name;
            existSuggestion.PersonCount = suggestion.PersonCount;


            _context.SaveChanges();

            if (oldFileName != null)
                FileManager.Delete(_env.WebRootPath, "uploads/suggestion", oldFileName);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Suggestion suggestion = _context.Suggestions.Find(id);

            if (suggestion == null) return StatusCode(404);

            _context.Suggestions.Remove(suggestion);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/suggestion", suggestion.Image);

            return StatusCode(200);
        }
    }
}

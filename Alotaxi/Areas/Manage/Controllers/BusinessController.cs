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
    public class BusinessController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public IWebHostEnvironment _env { get; }

        public BusinessController(AlotaxiDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Customers.AsQueryable();


            return View(PaginatedList<Customer>.Create(query, page, 6));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (customer.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }

            customer.Image = FileManager.Save(_env.WebRootPath, "uploads/customer", customer.ImageFile);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Customer customer = _context.Customers.Find(id);

            if (customer == null) return View("Error");

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            Customer existCustomer = _context.Customers.Find(customer.Id);

            if (existCustomer == null) return View("Error");


            string oldFileName = null;
            if (customer.ImageFile != null)
            {
                oldFileName = existCustomer.Image;
                existCustomer.Image = FileManager.Save(_env.WebRootPath, "uploads/customer", customer.ImageFile);
            }

            existCustomer.Name = customer.Name;

            _context.SaveChanges();

            if (oldFileName != null)
                FileManager.Delete(_env.WebRootPath, "uploads/customer", oldFileName);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Customer customer = _context.Customers.Find(id);

            if (customer == null) return StatusCode(404);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/customer", customer.Image);

            return StatusCode(200);
        }
    }
}

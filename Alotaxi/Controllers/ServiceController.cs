using Alotaxi.DAL;
using Alotaxi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alotaxi.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AlotaxiDbContext _context;

        public ServiceController(AlotaxiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Categorie> services = _context.Categories.ToList(); 
            return View(services);
        }
    }
}

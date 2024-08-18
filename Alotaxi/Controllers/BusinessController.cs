using Alotaxi.DAL;
using Alotaxi.Models;
using Alotaxi.Services;
using Alotaxi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alotaxi.Controllers
{
    public class BusinessController : Controller
    {
        private readonly AlotaxiDbContext _contex;
        private readonly IEmailSender _emailSender;

        public BusinessController(AlotaxiDbContext contex, IEmailSender emailSender)
        {
            _contex = contex;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            BusinessViewModel viewModel = new BusinessViewModel
            {
                Settings = _contex.Settings.ToList(),
                Customers = _contex.Customers.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ContactPageMessageViewModel vm)
        {
            Settings settings = _contex.Settings.FirstOrDefault();

            string messageBody = $@"
             <p><strong>Şirkət Adı:</strong> {vm.Fullname}</p>
             <p><strong>Telefon:</strong> {vm.Phone}</p>
             <p><strong>E-Mail:</strong> {vm.Email}</p>
             <p><strong>Mesaj:</strong> {vm.Message}</p>";

            _emailSender.Send(settings.Email, "Saytadan Korporativ Mesaj", messageBody);

            BusinessViewModel viewModel = new BusinessViewModel
            {
                Settings = _contex.Settings.ToList(),
                Customers = _contex.Customers.ToList()
            };

            return View(viewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PrescriptionList.Models;

namespace PrescriptionList.Controllers
{
    public class HomeController : Controller
    {
        private PrescriptionContext context { get; set; }

        public HomeController(PrescriptionContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var prescriptions = context.Prescriptions.OrderBy(m => m.MedicationName).ToList();
            return View(prescriptions);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
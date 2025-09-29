using Microsoft.AspNetCore.Mvc;
using PrescriptionList.Models; 

namespace PrescriptionList.Controllers
{
    public class PrescriptionController : Controller
    {
        private PrescriptionContext context { get; set; }

        public PrescriptionController(PrescriptionContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Prescription());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var prescription = context.Prescriptions.Find(id);
            return View("Edit", prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                if (prescription.PrescriptionId == 0)
                    context.Prescriptions.Add(prescription);
                else
                    context.Prescriptions.Update(prescription);

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (prescription.PrescriptionId == 0) ? "Add" : "Edit";
                return View("Edit", prescription);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = context.Prescriptions.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Delete(Prescription prescription)
        {
            context.Prescriptions.Remove(prescription);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
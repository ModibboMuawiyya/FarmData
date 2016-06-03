using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ExporterPaymentsController : Controller
    {
        private ApplicationDbContext _context;

        public ExporterPaymentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ExporterPayments
        public IActionResult Index()
        {
            return View(_context.ExporterPayment.ToList());
        }

        // GET: ExporterPayments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterPayment exporterPayment = _context.ExporterPayment.Single(m => m.ExporterId == id);
            if (exporterPayment == null)
            {
                return HttpNotFound();
            }

            return View(exporterPayment);
        }

        // GET: ExporterPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExporterPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExporterPayment exporterPayment)
        {
            if (ModelState.IsValid)
            {
                _context.ExporterPayment.Add(exporterPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporterPayment);
        }

        // GET: ExporterPayments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterPayment exporterPayment = _context.ExporterPayment.Single(m => m.ExporterId == id);
            if (exporterPayment == null)
            {
                return HttpNotFound();
            }
            return View(exporterPayment);
        }

        // POST: ExporterPayments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExporterPayment exporterPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(exporterPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporterPayment);
        }

        // GET: ExporterPayments/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterPayment exporterPayment = _context.ExporterPayment.Single(m => m.ExporterId == id);
            if (exporterPayment == null)
            {
                return HttpNotFound();
            }

            return View(exporterPayment);
        }

        // POST: ExporterPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ExporterPayment exporterPayment = _context.ExporterPayment.Single(m => m.ExporterId == id);
            _context.ExporterPayment.Remove(exporterPayment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

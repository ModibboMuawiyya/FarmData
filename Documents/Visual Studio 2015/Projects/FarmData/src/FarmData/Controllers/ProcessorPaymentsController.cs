using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ProcessorPaymentsController : Controller
    {
        private ApplicationDbContext _context;

        public ProcessorPaymentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProcessorPayments
        public IActionResult Index()
        {
            return View(_context.ProcessorPayment.ToList());
        }

        // GET: ProcessorPayments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorPayment processorPayment = _context.ProcessorPayment.Single(m => m.CompanyId == id);
            if (processorPayment == null)
            {
                return HttpNotFound();
            }

            return View(processorPayment);
        }

        // GET: ProcessorPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessorPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcessorPayment processorPayment)
        {
            if (ModelState.IsValid)
            {
                _context.ProcessorPayment.Add(processorPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorPayment);
        }

        // GET: ProcessorPayments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorPayment processorPayment = _context.ProcessorPayment.Single(m => m.CompanyId == id);
            if (processorPayment == null)
            {
                return HttpNotFound();
            }
            return View(processorPayment);
        }

        // POST: ProcessorPayments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProcessorPayment processorPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(processorPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorPayment);
        }

        // GET: ProcessorPayments/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorPayment processorPayment = _context.ProcessorPayment.Single(m => m.CompanyId == id);
            if (processorPayment == null)
            {
                return HttpNotFound();
            }

            return View(processorPayment);
        }

        // POST: ProcessorPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProcessorPayment processorPayment = _context.ProcessorPayment.Single(m => m.CompanyId == id);
            _context.ProcessorPayment.Remove(processorPayment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

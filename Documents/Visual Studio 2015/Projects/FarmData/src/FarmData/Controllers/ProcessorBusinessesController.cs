using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ProcessorBusinessesController : Controller
    {
        private ApplicationDbContext _context;

        public ProcessorBusinessesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProcessorBusinesses
        public IActionResult Index()
        {
            return View(_context.ProcessorBusiness.ToList());
        }

        // GET: ProcessorBusinesses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorBusiness processorBusiness = _context.ProcessorBusiness.Single(m => m.CompanyId == id);
            if (processorBusiness == null)
            {
                return HttpNotFound();
            }

            return View(processorBusiness);
        }

        // GET: ProcessorBusinesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessorBusinesses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcessorBusiness processorBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.ProcessorBusiness.Add(processorBusiness);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorBusiness);
        }

        // GET: ProcessorBusinesses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorBusiness processorBusiness = _context.ProcessorBusiness.Single(m => m.CompanyId == id);
            if (processorBusiness == null)
            {
                return HttpNotFound();
            }
            return View(processorBusiness);
        }

        // POST: ProcessorBusinesses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProcessorBusiness processorBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Update(processorBusiness);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorBusiness);
        }

        // GET: ProcessorBusinesses/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorBusiness processorBusiness = _context.ProcessorBusiness.Single(m => m.CompanyId == id);
            if (processorBusiness == null)
            {
                return HttpNotFound();
            }

            return View(processorBusiness);
        }

        // POST: ProcessorBusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProcessorBusiness processorBusiness = _context.ProcessorBusiness.Single(m => m.CompanyId == id);
            _context.ProcessorBusiness.Remove(processorBusiness);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

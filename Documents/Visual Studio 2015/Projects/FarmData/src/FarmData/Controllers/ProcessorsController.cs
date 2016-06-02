using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ProcessorsController : Controller
    {
        private ApplicationDbContext _context;

        public ProcessorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Processors
        public IActionResult Index()
        {
            return View(_context.Processor.ToList());
        }

        // GET: Processors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Processor processor = _context.Processor.Single(m => m.CompanyId == id);
            if (processor == null)
            {
                return HttpNotFound();
            }

            return View(processor);
        }

        // GET: Processors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Processor processor)
        {
            if (ModelState.IsValid)
            {
                _context.Processor.Add(processor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processor);
        }

        // GET: Processors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Processor processor = _context.Processor.Single(m => m.CompanyId == id);
            if (processor == null)
            {
                return HttpNotFound();
            }
            return View(processor);
        }

        // POST: Processors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Processor processor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(processor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processor);
        }

        // GET: Processors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Processor processor = _context.Processor.Single(m => m.CompanyId == id);
            if (processor == null)
            {
                return HttpNotFound();
            }

            return View(processor);
        }

        // POST: Processors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Processor processor = _context.Processor.Single(m => m.CompanyId == id);
            _context.Processor.Remove(processor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

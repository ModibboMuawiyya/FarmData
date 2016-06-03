using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ExporterCartegoriesController : Controller
    {
        private ApplicationDbContext _context;

        public ExporterCartegoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ExporterCartegories
        public IActionResult Index()
        {
            return View(_context.ExporterCartegories.ToList());
        }

        // GET: ExporterCartegories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterCartegories exporterCartegories = _context.ExporterCartegories.Single(m => m.ExporterId == id);
            if (exporterCartegories == null)
            {
                return HttpNotFound();
            }

            return View(exporterCartegories);
        }

        // GET: ExporterCartegories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExporterCartegories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExporterCartegories exporterCartegories)
        {
            if (ModelState.IsValid)
            {
                _context.ExporterCartegories.Add(exporterCartegories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporterCartegories);
        }

        // GET: ExporterCartegories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterCartegories exporterCartegories = _context.ExporterCartegories.Single(m => m.ExporterId == id);
            if (exporterCartegories == null)
            {
                return HttpNotFound();
            }
            return View(exporterCartegories);
        }

        // POST: ExporterCartegories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExporterCartegories exporterCartegories)
        {
            if (ModelState.IsValid)
            {
                _context.Update(exporterCartegories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporterCartegories);
        }

        // GET: ExporterCartegories/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ExporterCartegories exporterCartegories = _context.ExporterCartegories.Single(m => m.ExporterId == id);
            if (exporterCartegories == null)
            {
                return HttpNotFound();
            }

            return View(exporterCartegories);
        }

        // POST: ExporterCartegories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ExporterCartegories exporterCartegories = _context.ExporterCartegories.Single(m => m.ExporterId == id);
            _context.ExporterCartegories.Remove(exporterCartegories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ExportersController : Controller
    {
        private ApplicationDbContext _context;

        public ExportersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Exporters
        public IActionResult Index()
        {
            return View(_context.Exporter.ToList());
        }

        // GET: Exporters/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exporter exporter = _context.Exporter.Single(m => m.ExporterId == id);
            if (exporter == null)
            {
                return HttpNotFound();
            }

            return View(exporter);
        }

        // GET: Exporters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exporters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exporter exporter)
        {
            if (ModelState.IsValid)
            {
                _context.Exporter.Add(exporter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporter);
        }

        // GET: Exporters/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exporter exporter = _context.Exporter.Single(m => m.ExporterId == id);
            if (exporter == null)
            {
                return HttpNotFound();
            }
            return View(exporter);
        }

        // POST: Exporters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exporter exporter)
        {
            if (ModelState.IsValid)
            {
                _context.Update(exporter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exporter);
        }

        // GET: Exporters/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exporter exporter = _context.Exporter.Single(m => m.ExporterId == id);
            if (exporter == null)
            {
                return HttpNotFound();
            }

            return View(exporter);
        }

        // POST: Exporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Exporter exporter = _context.Exporter.Single(m => m.ExporterId == id);
            _context.Exporter.Remove(exporter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

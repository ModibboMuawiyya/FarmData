using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class CooperativesController : Controller
    {
        private ApplicationDbContext _context;

        public CooperativesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cooperatives
        public IActionResult Index()
        {
            var applicationDbContext = _context.Cooperatives.Include(c => c.Cluster);
            return View(applicationDbContext.ToList());
        }

        // GET: Cooperatives/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cooperatives cooperatives = _context.Cooperatives.Single(m => m.CooperativeId == id);
            if (cooperatives == null)
            {
                return HttpNotFound();
            }

            return View(cooperatives);
        }

        // GET: Cooperatives/Create
        public IActionResult Create()
        {
            ViewData["ClusterId"] = new SelectList(_context.Cluster, "ClusterId", "Cluster");
            return View();
        }

        // POST: Cooperatives/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cooperatives cooperatives)
        {
            if (ModelState.IsValid)
            {
                _context.Cooperatives.Add(cooperatives);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ClusterId"] = new SelectList(_context.Cluster, "ClusterId", "Cluster", cooperatives.ClusterId);
            return View(cooperatives);
        }

        // GET: Cooperatives/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cooperatives cooperatives = _context.Cooperatives.Single(m => m.CooperativeId == id);
            if (cooperatives == null)
            {
                return HttpNotFound();
            }
            ViewData["ClusterId"] = new SelectList(_context.Cluster, "ClusterId", "Cluster", cooperatives.ClusterId);
            return View(cooperatives);
        }

        // POST: Cooperatives/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cooperatives cooperatives)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cooperatives);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ClusterId"] = new SelectList(_context.Cluster, "ClusterId", "Cluster", cooperatives.ClusterId);
            return View(cooperatives);
        }

        // GET: Cooperatives/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cooperatives cooperatives = _context.Cooperatives.Single(m => m.CooperativeId == id);
            if (cooperatives == null)
            {
                return HttpNotFound();
            }

            return View(cooperatives);
        }

        // POST: Cooperatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Cooperatives cooperatives = _context.Cooperatives.Single(m => m.CooperativeId == id);
            _context.Cooperatives.Remove(cooperatives);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ClustersController : Controller
    {
        private ApplicationDbContext _context;

        public ClustersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Clusters
        public IActionResult Index()
        {
            var applicationDbContext = _context.Cluster.Include(c => c.Farmer);
            return View(applicationDbContext.ToList());
        }

        // GET: Clusters/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cluster cluster = _context.Cluster.Single(m => m.ClusterId == id);
            if (cluster == null)
            {
                return HttpNotFound();
            }

            return View(cluster);
        }

        // GET: Clusters/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer");
            return View();
        }

        // POST: Clusters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                _context.Cluster.Add(cluster);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", cluster.FarmerId);
            return View(cluster);
        }

        // GET: Clusters/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cluster cluster = _context.Cluster.Single(m => m.ClusterId == id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", cluster.FarmerId);
            return View(cluster);
        }

        // POST: Clusters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cluster);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", cluster.FarmerId);
            return View(cluster);
        }

        // GET: Clusters/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cluster cluster = _context.Cluster.Single(m => m.ClusterId == id);
            if (cluster == null)
            {
                return HttpNotFound();
            }

            return View(cluster);
        }

        // POST: Clusters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Cluster cluster = _context.Cluster.Single(m => m.ClusterId == id);
            _context.Cluster.Remove(cluster);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ClusterFarmersController : Controller
    {
        private ApplicationDbContext _context;

        public ClusterFarmersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ClusterFarmers
        public IActionResult Index()
        {
            return View(_context.ClusterFarmer.ToList());
        }

        // GET: ClusterFarmers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ClusterFarmer clusterFarmer = _context.ClusterFarmer.Single(m => m.FarmerId == id);
            if (clusterFarmer == null)
            {
                return HttpNotFound();
            }

            return View(clusterFarmer);
        }

        // GET: ClusterFarmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClusterFarmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClusterFarmer clusterFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.ClusterFarmer.Add(clusterFarmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clusterFarmer);
        }

        // GET: ClusterFarmers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ClusterFarmer clusterFarmer = _context.ClusterFarmer.Single(m => m.FarmerId == id);
            if (clusterFarmer == null)
            {
                return HttpNotFound();
            }
            return View(clusterFarmer);
        }

        // POST: ClusterFarmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClusterFarmer clusterFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(clusterFarmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clusterFarmer);
        }

        // GET: ClusterFarmers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ClusterFarmer clusterFarmer = _context.ClusterFarmer.Single(m => m.FarmerId == id);
            if (clusterFarmer == null)
            {
                return HttpNotFound();
            }

            return View(clusterFarmer);
        }

        // POST: ClusterFarmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ClusterFarmer clusterFarmer = _context.ClusterFarmer.Single(m => m.FarmerId == id);
            _context.ClusterFarmer.Remove(clusterFarmer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

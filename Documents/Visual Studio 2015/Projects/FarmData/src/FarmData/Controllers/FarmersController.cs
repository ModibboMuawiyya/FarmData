using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class FarmersController : Controller
    {
        private ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Farmers
        public IActionResult Index()
        {
            return View(_context.Farmer.ToList());
        }

        // GET: Farmers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer farmer = _context.Farmer.Single(m => m.FarmerId == id);
            if (farmer == null)
            {
                return HttpNotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Farmer.Add(farmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer farmer = _context.Farmer.Single(m => m.FarmerId == id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(farmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer farmer = _context.Farmer.Single(m => m.FarmerId == id);
            if (farmer == null)
            {
                return HttpNotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Farmer farmer = _context.Farmer.Single(m => m.FarmerId == id);
            _context.Farmer.Remove(farmer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

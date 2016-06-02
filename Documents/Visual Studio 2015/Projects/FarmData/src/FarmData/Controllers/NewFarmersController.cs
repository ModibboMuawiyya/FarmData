using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class NewFarmersController : Controller
    {
        private ApplicationDbContext _context;

        public NewFarmersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: NewFarmers
        public IActionResult Index()
        {
            return View(_context.NewFarmer.ToList());
        }

        // GET: NewFarmers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewFarmer newFarmer = _context.NewFarmer.Single(m => m.NewId == id);
            if (newFarmer == null)
            {
                return HttpNotFound();
            }

            return View(newFarmer);
        }

        // GET: NewFarmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewFarmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewFarmer newFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.NewFarmer.Add(newFarmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newFarmer);
        }

        // GET: NewFarmers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewFarmer newFarmer = _context.NewFarmer.Single(m => m.NewId == id);
            if (newFarmer == null)
            {
                return HttpNotFound();
            }
            return View(newFarmer);
        }

        // POST: NewFarmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewFarmer newFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(newFarmer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newFarmer);
        }

        // GET: NewFarmers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewFarmer newFarmer = _context.NewFarmer.Single(m => m.NewId == id);
            if (newFarmer == null)
            {
                return HttpNotFound();
            }

            return View(newFarmer);
        }

        // POST: NewFarmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            NewFarmer newFarmer = _context.NewFarmer.Single(m => m.NewId == id);
            _context.NewFarmer.Remove(newFarmer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

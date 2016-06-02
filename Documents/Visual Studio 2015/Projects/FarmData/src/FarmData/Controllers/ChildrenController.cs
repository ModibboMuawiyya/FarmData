using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ChildrenController : Controller
    {
        private ApplicationDbContext _context;

        public ChildrenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Children
        public IActionResult Index()
        {
            var applicationDbContext = _context.Child.Include(c => c.Farmer);
            return View(applicationDbContext.ToList());
        }

        // GET: Children/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Child child = _context.Child.Single(m => m.ChildId == id);
            if (child == null)
            {
                return HttpNotFound();
            }

            return View(child);
        }

        // GET: Children/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer");
            return View();
        }

        // POST: Children/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Child child)
        {
            if (ModelState.IsValid)
            {
                _context.Child.Add(child);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", child.FarmerId);
            return View(child);
        }

        // GET: Children/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Child child = _context.Child.Single(m => m.ChildId == id);
            if (child == null)
            {
                return HttpNotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", child.FarmerId);
            return View(child);
        }

        // POST: Children/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Child child)
        {
            if (ModelState.IsValid)
            {
                _context.Update(child);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", child.FarmerId);
            return View(child);
        }

        // GET: Children/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Child child = _context.Child.Single(m => m.ChildId == id);
            if (child == null)
            {
                return HttpNotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Child child = _context.Child.Single(m => m.ChildId == id);
            _context.Child.Remove(child);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

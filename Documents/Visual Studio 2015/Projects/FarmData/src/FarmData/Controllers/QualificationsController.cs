using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class QualificationsController : Controller
    {
        private ApplicationDbContext _context;

        public QualificationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Qualifications
        public IActionResult Index()
        {
            var applicationDbContext = _context.Qualification.Include(q => q.NewFarmer);
            return View(applicationDbContext.ToList());
        }

        // GET: Qualifications/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Qualification qualification = _context.Qualification.Single(m => m.QuaificationId == id);
            if (qualification == null)
            {
                return HttpNotFound();
            }

            return View(qualification);
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer");
            return View();
        }

        // POST: Qualifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Qualification.Add(qualification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", qualification.NewId);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Qualification qualification = _context.Qualification.Single(m => m.QuaificationId == id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", qualification.NewId);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Update(qualification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", qualification.NewId);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Qualification qualification = _context.Qualification.Single(m => m.QuaificationId == id);
            if (qualification == null)
            {
                return HttpNotFound();
            }

            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = _context.Qualification.Single(m => m.QuaificationId == id);
            _context.Qualification.Remove(qualification);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

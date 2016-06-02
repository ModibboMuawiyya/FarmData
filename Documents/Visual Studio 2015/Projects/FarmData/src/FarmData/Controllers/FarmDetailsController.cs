using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class FarmDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public FarmDetailsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: FarmDetails
        public IActionResult Index()
        {
            var applicationDbContext = _context.FarmDetail.Include(f => f.Farmer);
            return View(applicationDbContext.ToList());
        }

        // GET: FarmDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmDetail farmDetail = _context.FarmDetail.Single(m => m.FarmId == id);
            if (farmDetail == null)
            {
                return HttpNotFound();
            }

            return View(farmDetail);
        }

        // GET: FarmDetails/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer");
            return View();
        }

        // POST: FarmDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FarmDetail farmDetail)
        {
            if (ModelState.IsValid)
            {
                _context.FarmDetail.Add(farmDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", farmDetail.FarmerId);
            return View(farmDetail);
        }

        // GET: FarmDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmDetail farmDetail = _context.FarmDetail.Single(m => m.FarmId == id);
            if (farmDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", farmDetail.FarmerId);
            return View(farmDetail);
        }

        // POST: FarmDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FarmDetail farmDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Update(farmDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmer, "FarmerId", "Farmer", farmDetail.FarmerId);
            return View(farmDetail);
        }

        // GET: FarmDetails/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmDetail farmDetail = _context.FarmDetail.Single(m => m.FarmId == id);
            if (farmDetail == null)
            {
                return HttpNotFound();
            }

            return View(farmDetail);
        }

        // POST: FarmDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            FarmDetail farmDetail = _context.FarmDetail.Single(m => m.FarmId == id);
            _context.FarmDetail.Remove(farmDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

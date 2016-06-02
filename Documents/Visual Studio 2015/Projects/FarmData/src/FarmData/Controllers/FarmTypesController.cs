using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class FarmTypesController : Controller
    {
        private ApplicationDbContext _context;

        public FarmTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: FarmTypes
        public IActionResult Index()
        {
            return View(_context.FarmType.ToList());
        }

        // GET: FarmTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmType farmType = _context.FarmType.Single(m => m.FarmTypeId == id);
            if (farmType == null)
            {
                return HttpNotFound();
            }

            return View(farmType);
        }

        // GET: FarmTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FarmType farmType)
        {
            if (ModelState.IsValid)
            {
                _context.FarmType.Add(farmType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmType);
        }

        // GET: FarmTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmType farmType = _context.FarmType.Single(m => m.FarmTypeId == id);
            if (farmType == null)
            {
                return HttpNotFound();
            }
            return View(farmType);
        }

        // POST: FarmTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FarmType farmType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(farmType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmType);
        }

        // GET: FarmTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FarmType farmType = _context.FarmType.Single(m => m.FarmTypeId == id);
            if (farmType == null)
            {
                return HttpNotFound();
            }

            return View(farmType);
        }

        // POST: FarmTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            FarmType farmType = _context.FarmType.Single(m => m.FarmTypeId == id);
            _context.FarmType.Remove(farmType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

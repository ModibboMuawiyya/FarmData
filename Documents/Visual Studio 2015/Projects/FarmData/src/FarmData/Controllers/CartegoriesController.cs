using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class CartegoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CartegoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cartegories
        public IActionResult Index()
        {
            return View(_context.Cartegories.ToList());
        }

        // GET: Cartegories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cartegories cartegories = _context.Cartegories.Single(m => m.CartegoriesId == id);
            if (cartegories == null)
            {
                return HttpNotFound();
            }

            return View(cartegories);
        }

        // GET: Cartegories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartegories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cartegories cartegories)
        {
            if (ModelState.IsValid)
            {
                _context.Cartegories.Add(cartegories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartegories);
        }

        // GET: Cartegories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cartegories cartegories = _context.Cartegories.Single(m => m.CartegoriesId == id);
            if (cartegories == null)
            {
                return HttpNotFound();
            }
            return View(cartegories);
        }

        // POST: Cartegories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cartegories cartegories)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cartegories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartegories);
        }

        // GET: Cartegories/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cartegories cartegories = _context.Cartegories.Single(m => m.CartegoriesId == id);
            if (cartegories == null)
            {
                return HttpNotFound();
            }

            return View(cartegories);
        }

        // POST: Cartegories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Cartegories cartegories = _context.Cartegories.Single(m => m.CartegoriesId == id);
            _context.Cartegories.Remove(cartegories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

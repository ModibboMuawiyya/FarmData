using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class LookUPProductsController : Controller
    {
        private ApplicationDbContext _context;

        public LookUPProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: LookUPProducts
        public IActionResult Index()
        {
            return View(_context.LookUPProduct.ToList());
        }

        // GET: LookUPProducts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LookUPProduct lookUPProduct = _context.LookUPProduct.Single(m => m.ProductId == id);
            if (lookUPProduct == null)
            {
                return HttpNotFound();
            }

            return View(lookUPProduct);
        }

        // GET: LookUPProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUPProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LookUPProduct lookUPProduct)
        {
            if (ModelState.IsValid)
            {
                _context.LookUPProduct.Add(lookUPProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lookUPProduct);
        }

        // GET: LookUPProducts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LookUPProduct lookUPProduct = _context.LookUPProduct.Single(m => m.ProductId == id);
            if (lookUPProduct == null)
            {
                return HttpNotFound();
            }
            return View(lookUPProduct);
        }

        // POST: LookUPProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LookUPProduct lookUPProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Update(lookUPProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lookUPProduct);
        }

        // GET: LookUPProducts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LookUPProduct lookUPProduct = _context.LookUPProduct.Single(m => m.ProductId == id);
            if (lookUPProduct == null)
            {
                return HttpNotFound();
            }

            return View(lookUPProduct);
        }

        // POST: LookUPProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            LookUPProduct lookUPProduct = _context.LookUPProduct.Single(m => m.ProductId == id);
            _context.LookUPProduct.Remove(lookUPProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

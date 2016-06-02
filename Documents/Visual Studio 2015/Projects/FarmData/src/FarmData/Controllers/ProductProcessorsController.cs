using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ProductProcessorsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductProcessorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProductProcessors
        public IActionResult Index()
        {
            return View(_context.ProductProcessor.ToList());
        }

        // GET: ProductProcessors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductProcessor productProcessor = _context.ProductProcessor.Single(m => m.CompanyId == id);
            if (productProcessor == null)
            {
                return HttpNotFound();
            }

            return View(productProcessor);
        }

        // GET: ProductProcessors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductProcessors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductProcessor productProcessor)
        {
            if (ModelState.IsValid)
            {
                _context.ProductProcessor.Add(productProcessor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productProcessor);
        }

        // GET: ProductProcessors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductProcessor productProcessor = _context.ProductProcessor.Single(m => m.CompanyId == id);
            if (productProcessor == null)
            {
                return HttpNotFound();
            }
            return View(productProcessor);
        }

        // POST: ProductProcessors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductProcessor productProcessor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(productProcessor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productProcessor);
        }

        // GET: ProductProcessors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductProcessor productProcessor = _context.ProductProcessor.Single(m => m.CompanyId == id);
            if (productProcessor == null)
            {
                return HttpNotFound();
            }

            return View(productProcessor);
        }

        // POST: ProductProcessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProductProcessor productProcessor = _context.ProductProcessor.Single(m => m.CompanyId == id);
            _context.ProductProcessor.Remove(productProcessor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

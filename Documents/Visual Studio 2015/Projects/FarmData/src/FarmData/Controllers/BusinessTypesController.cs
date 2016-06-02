using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class BusinessTypesController : Controller
    {
        private ApplicationDbContext _context;

        public BusinessTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: BusinessTypes
        public IActionResult Index()
        {
            return View(_context.BusinessType.ToList());
        }

        // GET: BusinessTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessType businessType = _context.BusinessType.Single(m => m.BusinessId == id);
            if (businessType == null)
            {
                return HttpNotFound();
            }

            return View(businessType);
        }

        // GET: BusinessTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusinessType businessType)
        {
            if (ModelState.IsValid)
            {
                _context.BusinessType.Add(businessType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessType);
        }

        // GET: BusinessTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessType businessType = _context.BusinessType.Single(m => m.BusinessId == id);
            if (businessType == null)
            {
                return HttpNotFound();
            }
            return View(businessType);
        }

        // POST: BusinessTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BusinessType businessType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(businessType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessType);
        }

        // GET: BusinessTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessType businessType = _context.BusinessType.Single(m => m.BusinessId == id);
            if (businessType == null)
            {
                return HttpNotFound();
            }

            return View(businessType);
        }

        // POST: BusinessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BusinessType businessType = _context.BusinessType.Single(m => m.BusinessId == id);
            _context.BusinessType.Remove(businessType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class Farmer_PaymentController : Controller
    {
        private ApplicationDbContext _context;

        public Farmer_PaymentController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Farmer_Payment
        public IActionResult Index()
        {
            return View(_context.Farmer_Payment.ToList());
        }

        // GET: Farmer_Payment/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer_Payment farmer_Payment = _context.Farmer_Payment.Single(m => m.FarmerId == id);
            if (farmer_Payment == null)
            {
                return HttpNotFound();
            }

            return View(farmer_Payment);
        }

        // GET: Farmer_Payment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmer_Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farmer_Payment farmer_Payment)
        {
            if (ModelState.IsValid)
            {
                _context.Farmer_Payment.Add(farmer_Payment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer_Payment);
        }

        // GET: Farmer_Payment/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer_Payment farmer_Payment = _context.Farmer_Payment.Single(m => m.FarmerId == id);
            if (farmer_Payment == null)
            {
                return HttpNotFound();
            }
            return View(farmer_Payment);
        }

        // POST: Farmer_Payment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Farmer_Payment farmer_Payment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(farmer_Payment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer_Payment);
        }

        // GET: Farmer_Payment/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Farmer_Payment farmer_Payment = _context.Farmer_Payment.Single(m => m.FarmerId == id);
            if (farmer_Payment == null)
            {
                return HttpNotFound();
            }

            return View(farmer_Payment);
        }

        // POST: Farmer_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Farmer_Payment farmer_Payment = _context.Farmer_Payment.Single(m => m.FarmerId == id);
            _context.Farmer_Payment.Remove(farmer_Payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

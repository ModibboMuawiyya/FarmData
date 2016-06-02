using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class UserPaymentsController : Controller
    {
        private ApplicationDbContext _context;

        public UserPaymentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserPayments
        public IActionResult Index()
        {
            return View(_context.UserPayment.ToList());
        }

        // GET: UserPayments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserPayment userPayment = _context.UserPayment.Single(m => m.NewId == id);
            if (userPayment == null)
            {
                return HttpNotFound();
            }

            return View(userPayment);
        }

        // GET: UserPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserPayment userPayment)
        {
            if (ModelState.IsValid)
            {
                _context.UserPayment.Add(userPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPayment);
        }

        // GET: UserPayments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserPayment userPayment = _context.UserPayment.Single(m => m.NewId == id);
            if (userPayment == null)
            {
                return HttpNotFound();
            }
            return View(userPayment);
        }

        // POST: UserPayments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserPayment userPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(userPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPayment);
        }

        // GET: UserPayments/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserPayment userPayment = _context.UserPayment.Single(m => m.NewId == id);
            if (userPayment == null)
            {
                return HttpNotFound();
            }

            return View(userPayment);
        }

        // POST: UserPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            UserPayment userPayment = _context.UserPayment.Single(m => m.NewId == id);
            _context.UserPayment.Remove(userPayment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

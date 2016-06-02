using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class NewUserBiosController : Controller
    {
        private ApplicationDbContext _context;

        public NewUserBiosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: NewUserBios
        public IActionResult Index()
        {
            return View(_context.NewUserBio.ToList());
        }

        // GET: NewUserBios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewUserBio newUserBio = _context.NewUserBio.Single(m => m.NewId == id);
            if (newUserBio == null)
            {
                return HttpNotFound();
            }

            return View(newUserBio);
        }

        // GET: NewUserBios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewUserBios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewUserBio newUserBio)
        {
            if (ModelState.IsValid)
            {
                _context.NewUserBio.Add(newUserBio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUserBio);
        }

        // GET: NewUserBios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewUserBio newUserBio = _context.NewUserBio.Single(m => m.NewId == id);
            if (newUserBio == null)
            {
                return HttpNotFound();
            }
            return View(newUserBio);
        }

        // POST: NewUserBios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewUserBio newUserBio)
        {
            if (ModelState.IsValid)
            {
                _context.Update(newUserBio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUserBio);
        }

        // GET: NewUserBios/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            NewUserBio newUserBio = _context.NewUserBio.Single(m => m.NewId == id);
            if (newUserBio == null)
            {
                return HttpNotFound();
            }

            return View(newUserBio);
        }

        // POST: NewUserBios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            NewUserBio newUserBio = _context.NewUserBio.Single(m => m.NewId == id);
            _context.NewUserBio.Remove(newUserBio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

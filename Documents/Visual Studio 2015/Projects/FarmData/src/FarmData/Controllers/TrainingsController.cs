using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class TrainingsController : Controller
    {
        private ApplicationDbContext _context;

        public TrainingsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trainings
        public IActionResult Index()
        {
            var applicationDbContext = _context.Training.Include(t => t.NewFarmer);
            return View(applicationDbContext.ToList());
        }

        // GET: Trainings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Training training = _context.Training.Single(m => m.TrainId == id);
            if (training == null)
            {
                return HttpNotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer");
            return View();
        }

        // POST: Trainings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Training.Add(training);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", training.NewId);
            return View(training);
        }

        // GET: Trainings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Training training = _context.Training.Single(m => m.TrainId == id);
            if (training == null)
            {
                return HttpNotFound();
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", training.NewId);
            return View(training);
        }

        // POST: Trainings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Update(training);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["NewId"] = new SelectList(_context.NewFarmer, "NewId", "NewFarmer", training.NewId);
            return View(training);
        }

        // GET: Trainings/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Training training = _context.Training.Single(m => m.TrainId == id);
            if (training == null)
            {
                return HttpNotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Training training = _context.Training.Single(m => m.TrainId == id);
            _context.Training.Remove(training);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

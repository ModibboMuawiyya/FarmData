using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class AgentsController : Controller
    {
        private ApplicationDbContext _context;

        public AgentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Agents
        public IActionResult Index()
        {
            return View(_context.Agent.ToList());
        }

        // GET: Agents/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agent agent = _context.Agent.Single(m => m.AgentId == id);
            if (agent == null)
            {
                return HttpNotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Agent.Add(agent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agent agent = _context.Agent.Single(m => m.AgentId == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Update(agent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Agent agent = _context.Agent.Single(m => m.AgentId == id);
            if (agent == null)
            {
                return HttpNotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Agent agent = _context.Agent.Single(m => m.AgentId == id);
            _context.Agent.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

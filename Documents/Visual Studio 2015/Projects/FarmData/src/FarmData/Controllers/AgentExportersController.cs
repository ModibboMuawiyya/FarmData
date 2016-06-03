using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class AgentExportersController : Controller
    {
        private ApplicationDbContext _context;

        public AgentExportersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: AgentExporters
        public IActionResult Index()
        {
            return View(_context.AgentExporter.ToList());
        }

        // GET: AgentExporters/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgentExporter agentExporter = _context.AgentExporter.Single(m => m.ExporterId == id);
            if (agentExporter == null)
            {
                return HttpNotFound();
            }

            return View(agentExporter);
        }

        // GET: AgentExporters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgentExporters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgentExporter agentExporter)
        {
            if (ModelState.IsValid)
            {
                _context.AgentExporter.Add(agentExporter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentExporter);
        }

        // GET: AgentExporters/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgentExporter agentExporter = _context.AgentExporter.Single(m => m.ExporterId == id);
            if (agentExporter == null)
            {
                return HttpNotFound();
            }
            return View(agentExporter);
        }

        // POST: AgentExporters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgentExporter agentExporter)
        {
            if (ModelState.IsValid)
            {
                _context.Update(agentExporter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentExporter);
        }

        // GET: AgentExporters/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgentExporter agentExporter = _context.AgentExporter.Single(m => m.ExporterId == id);
            if (agentExporter == null)
            {
                return HttpNotFound();
            }

            return View(agentExporter);
        }

        // POST: AgentExporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            AgentExporter agentExporter = _context.AgentExporter.Single(m => m.ExporterId == id);
            _context.AgentExporter.Remove(agentExporter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

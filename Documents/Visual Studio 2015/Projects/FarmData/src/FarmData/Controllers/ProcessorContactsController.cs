using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Controllers
{
    public class ProcessorContactsController : Controller
    {
        private ApplicationDbContext _context;

        public ProcessorContactsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProcessorContacts
        public IActionResult Index()
        {
            return View(_context.ProcessorContact.ToList());
        }

        // GET: ProcessorContacts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorContact processorContact = _context.ProcessorContact.Single(m => m.CompanyId == id);
            if (processorContact == null)
            {
                return HttpNotFound();
            }

            return View(processorContact);
        }

        // GET: ProcessorContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessorContacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcessorContact processorContact)
        {
            if (ModelState.IsValid)
            {
                _context.ProcessorContact.Add(processorContact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorContact);
        }

        // GET: ProcessorContacts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorContact processorContact = _context.ProcessorContact.Single(m => m.CompanyId == id);
            if (processorContact == null)
            {
                return HttpNotFound();
            }
            return View(processorContact);
        }

        // POST: ProcessorContacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProcessorContact processorContact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(processorContact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processorContact);
        }

        // GET: ProcessorContacts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProcessorContact processorContact = _context.ProcessorContact.Single(m => m.CompanyId == id);
            if (processorContact == null)
            {
                return HttpNotFound();
            }

            return View(processorContact);
        }

        // POST: ProcessorContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProcessorContact processorContact = _context.ProcessorContact.Single(m => m.CompanyId == id);
            _context.ProcessorContact.Remove(processorContact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

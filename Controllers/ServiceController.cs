using Microsoft.AspNetCore.Mvc;
using RepairAndConstructionService.Data;
using RepairAndConstructionService.Models;
using System.Linq;

namespace RepairAndConstructionService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Service
        public IActionResult Index()
        {
            // Retrieve all services from the database
            var services = _context.Services.ToList();
            return View(services);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Service/Edit/{id}
        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Service/Edit
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Service/Delete/{id}
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Service/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RepairAndConstructionService.Data;
using RepairAndConstructionService.Models;

namespace RepairAndConstructionService.Controllers
{
    public class WorkerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Worker
        public IActionResult Index()
        {
            var workers = _context.Workers.ToList();
            return View(workers);
        }

        // GET: Worker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Workers.Add(worker);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Worker/Edit/{id}
        public IActionResult Edit(int id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Worker/Edit
        [HttpPost]
        public IActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Workers.Update(worker);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Worker/Delete/{id}
        public IActionResult Delete(int id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Worker/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Worker/Details/{id}
        public IActionResult Details(int id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }
    }
}

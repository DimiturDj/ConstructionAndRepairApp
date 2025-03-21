using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairAndConstructionService.Data;
using RepairAndConstructionService.Models;

namespace RepairAndConstructionService.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Review
        public IActionResult Index()
        {
            var reviews = _context.Reviews
                                  .Include(r => r.Customer)
                                  .Include(r => r.Worker)
                                  .ToList();
            return View(reviews);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Workers = _context.Workers.ToList();
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Delete/{id}
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

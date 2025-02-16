using Microsoft.AspNetCore.Mvc;
using RepairAndConstructionService.Data;
using RepairAndConstructionService.Models;

namespace RepairAndConstructionService.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobOfferController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobOffer
        public IActionResult Index()
        {
            var jobOffers = _context.JobOffers.ToList();
            return View(jobOffers);
        }

        // GET: JobOffer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobOffer/Create
        [HttpPost]
        public IActionResult Create(JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                _context.JobOffers.Add(jobOffer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(jobOffer);
        }

        // GET: JobOffer/Edit/{id}
        public IActionResult Edit(int id)
        {
            var jobOffer = _context.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffer/Edit
        [HttpPost]
        public IActionResult Edit(JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                _context.JobOffers.Update(jobOffer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(jobOffer);
        }

        // GET: JobOffer/Delete/{id}
        public IActionResult Delete(int id)
        {
            var jobOffer = _context.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffer/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobOffer = _context.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffers.Remove(jobOffer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: JobOffer/Details/{id}
        public IActionResult Details(int id)
        {
            var jobOffer = _context.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairAndConstructionService.Data;
using RepairAndConstructionService.Models;

namespace RepairAndConstructionService.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public IActionResult Index()
        {
            var bookings = _context.Bookings
                                   .Include(b => b.Customer)
                                   .Include(b => b.Worker)
                                   .Include(b => b.JobOffer)
                                   .ToList();
            return View(bookings);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Workers = _context.Workers.ToList();
            ViewBag.JobOffers = _context.JobOffers.ToList();
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Edit/{id}
        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Workers = _context.Workers.ToList();
            ViewBag.JobOffers = _context.JobOffers.ToList();
            return View(booking);
        }

        // POST: Booking/Edit
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Update(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Delete/{id}
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Booking/Details/{id}
        public IActionResult Details(int id)
        {
            var booking = _context.Bookings
                                   .Include(b => b.Customer)
                                   .Include(b => b.Worker)
                                   .Include(b => b.JobOffer)
                                   .FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}

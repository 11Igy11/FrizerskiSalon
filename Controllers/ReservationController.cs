using FrizerskiSalon1.Data;
using FrizerskiSalon1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FrizerskiSalon1.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET metoda za prikaz forme
        public IActionResult Create()
        {
            // Osiguraj da ViewBag.Services ima podatke
            ViewBag.Services = _context.Services.ToList();
            return View();
        }

        // POST metoda za spremanje rezervacije
        [HttpPost]
        public IActionResult Create(string CustomerName, string ReservationDate, int ServiceId)
        {
            try
            {
                // Parsiraj datum koristeći "dd/MM/yyyy"
                if (!DateTime.TryParseExact(ReservationDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
                {
                    ViewBag.ErrorMessage = "Datum rezervacije nije u ispravnom formatu. Koristite format dd/MM/yyyy.";
                    ViewBag.Services = _context.Services.ToList();
                    return View();
                }

                // Kreiraj novu rezervaciju
                var reservation = new Reservation
                {
                    CustomerName = CustomerName, // Ime klijenta
                    ReservationDate = parsedDate, // Datum rezervacije
                    TimeSlot = "12:00", // Postavite prema potrebama
                    UserId = 1, // Postavite prema potrebama
                    ServiceId = ServiceId // ID odabrane usluge
                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                return RedirectToAction("Confirmation"); // Nakon uspješne rezervacije, ide na potvrdu
            }
            catch (Exception ex)
            {
                // Logiranje greške
                Console.WriteLine($"Error: {ex.Message}");
                ViewBag.ErrorMessage = "Došlo je do greške prilikom spremanja rezervacije. Pokušajte ponovno.";
                ViewBag.Services = _context.Services.ToList();
                return View();
            }
        }

        // GET metoda za potvrdu rezervacije
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

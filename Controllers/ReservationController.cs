using Microsoft.AspNetCore.Mvc;

namespace FrizerskiSalon1.Controllers
{
    public class ReservationController : Controller
    {
        // Akcija za prikaz forme za kreiranje rezervacije
        public IActionResult Create()
        {
            return View();
        }
    }
}

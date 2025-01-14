using System.ComponentModel.DataAnnotations;

namespace FrizerskiSalon1.Models
{
    public class Reservation
    {
        public int Id { get; set; } // Primarni ključ

        [Required(ErrorMessage = "Ime klijenta je obavezno.")]
        public string CustomerName { get; set; } = string.Empty; // Ime klijenta

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum rezervacije je obavezan.")]
        public DateTime ReservationDate { get; set; } // Datum rezervacije

        [Required(ErrorMessage = "Termin rezervacije je obavezan.")]
        public string TimeSlot { get; set; } = string.Empty; // Termin rezervacije

        // Strani ključ za korisnika
        public int UserId { get; set; }
        public User User { get; set; } = null!; // Navigacijsko svojstvo prema korisniku

        // Strani ključ za uslugu
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!; // Navigacijsko svojstvo prema usluzi
    }
}

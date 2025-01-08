using System.ComponentModel.DataAnnotations;

namespace FrizerskiSalon1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Neispravan format email adrese.")]
        public string Email { get; set; } = string.Empty;

        public List<Reservation>? Reservations { get; set; } // Lista rezervacija povezane s korisnikom
    }
}

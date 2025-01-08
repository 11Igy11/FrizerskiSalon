using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrizerskiSalon1.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv usluge je obavezan.")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 9999.99, ErrorMessage = "Cijena mora biti između 0.01 i 9999.99.")]
        [DataType(DataType.Currency)] // Ovdje možeš dodati formatiranje kao valutu
        public decimal Price { get; set; }
    }
}

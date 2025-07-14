using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool EsGrupo { get; set; } // true = grupo scout, false = usuario individual

        [MaxLength(100)]
        public string? Rama { get; set; } // Tropa, Pioneros, Rovers, etc. Solo si aplica

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}

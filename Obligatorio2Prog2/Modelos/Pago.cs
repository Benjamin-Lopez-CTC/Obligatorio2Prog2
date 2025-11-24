using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Obligatorio2Prog2.Modelos
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        public int Turno_Id { get; set; }

        [Required]
        public DateOnly FechaPago { get; set; }

        [Required]
        public int MontoPago { get; set; }

        [Required]
        public string MetodoPago { get; set; }
    }
}

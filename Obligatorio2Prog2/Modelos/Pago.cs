using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Prog2.Modelos
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly FechaPago { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Ingrese un monto válido")]
        public int MontoPago { get; set; }

        [Required]
        [RegularExpression("^(Efectivo|Debito|Credito|Transferencia)$", ErrorMessage = "Método de pago inválido")]
        public string MetodoPago { get; set; }

        // Se mantiene sin navegación inversa a Turno para evitar ambigüedades en cascadas.
    }
}

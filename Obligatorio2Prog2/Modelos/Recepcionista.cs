using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Obligatorio2Prog2.Modelos
{
    public class Recepcionista
    {
        [Key]
        public int RecepcionistaId { get; set; }

        [Required]
        public string NombreR { get; set; }

        [Required]
        public string ApellidoR { get; set; }

        [Required]
        public int NumDocumentoR { get; set; }

        [Required]
        public string NombreUsuarioR { get; set; }

        [Required]
        public string ContraseniaR { get; set; }
    }
}

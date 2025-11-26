using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Obligatorio2Prog2.Modelos
{
    public class Recepcionista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecepcionistaId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El nombre debe contener entre 2 y 25 carácteres")]
        public string? NombreR { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El apellido debe contener entre 2 y 25 carácteres")]
        public string? ApellidoR { get; set; }

        [Required]
        [RegularExpression(@"^(\d{1}\.?\d{3}\.?\d{3}-?\d|\d{7,8})$",
             ErrorMessage = "Formato de cédula inválido.")]
        public string? NumDocumentoR { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El nombre de usuario debe contener entre 4 y 20 carácteres")]
        public string? NombreUsuarioR { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
            ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número y ser entre 8 y 15 carácteres")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 carácteres")]
        public string? ContraseniaR { get; set; }
    }
}

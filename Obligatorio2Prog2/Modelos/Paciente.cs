using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Prog2.Modelos
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El nombre debe contener entre 2 y 25 carácteres")]
        public string? NombreP { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El apellido debe contener entre 2 y 25 carácteres")]
        public string? ApellidoP { get; set; }

        [Required]
        [RegularExpression(@"^(\d{1}\.?\d{3}\.?\d{3}-?\d|\d{7,8})$",
             ErrorMessage = "Formato de cédula inválido.")]
        public string? NumDocumentoP { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|[12]\d|3[01])/(0[1-9]|1[0-2])/(19\d{2}|20\d{2})$", 
                ErrorMessage = "Ingrese una fecha válida.")]
        public DateOnly FechaNacP { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Ingrese un numero de telefono válido de 8 dígitos")]
        public string? TelefonoP { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Ingrese un Email válido")]
        public string? EmailP { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La obra social debe contener entre 6 y 20 carácteres")]
        public string? ObraSocialP { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El nombre de usuario debe contener entre 4 y 20 carácteres")]
        public string? NombreUsuarioP { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
            ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número y ser entre 8 y 15 carácteres")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 carácteres")]
        public string? ContraseniaP { get; set; }

        public List<Turno> Turnos { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Obligatorio2Prog2.Modelos
{
    [Index(nameof(MatriculaM), IsUnique = true)]
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El nombre debe contener entre 2 y 25 carácteres")]
        public string NombreM { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "El apellido debe contener entre 2 y 25 carácteres")]
        public string ApellidoM { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression("Cardiologia|Pediatria|Dermatologia|Traumatologia", ErrorMessage = "Especialidad invalida")]
        public string EspecialidadM { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "La matricula debe ser de 6 caracteres")]
        public string MatriculaM { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El nombre de usuario debe contener entre 4 y 20 carácteres")]
        public string NombreUsuarioM { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
            ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número y ser entre 8 y 15 carácteres")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 carácteres")]
        public string ContraseniaM { get; set; }

        public List<Hora> Horas { get; set; } = new List<Hora>();

        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace Obligatorio2Prog2.Modelos
{
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }

        [Required]
        public string NombreM { get; set; }

        [Required]
        public string ApellidoM { get; set; }

        [Required]
        public string EspecialidadM { get; set; }

        [Required]
        public string MatriculaM { get; set; }

        [Required]
        public string NombreUsuarioM { get; set; }

        [Required]
        public string ContraseniaM { get; set; }

        [Required]
        public string DiasAtencionM { get; set; }

        [Required]
        public string HoraDisponibleM { get; set; }
    }
}

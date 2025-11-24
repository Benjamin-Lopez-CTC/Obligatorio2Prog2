using System.ComponentModel.DataAnnotations;

namespace Obligatorio2Prog2.Modelos
{
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }

        [Required]
        public string NombreP { get; set; }

        [Required]
        public string ApellidoP { get; set; }

        [Required]
        public int NumDocumentoP { get; set; }

        [Required]
        public DateOnly FechaNacP { get; set; }

        [Required]
        public int TelefonoP { get; set; }

        [Required]
        public string EmailP { get; set; }

        [Required]
        public string ObraSocialP { get; set; }

        [Required]
        public string NombreUsuarioP { get; set; }

        [Required]
        public string ContraseniaP { get; set; }

    }
}

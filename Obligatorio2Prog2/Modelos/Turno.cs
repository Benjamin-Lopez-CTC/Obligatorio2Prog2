using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio2Prog2.Modelos
{
    public class Turno
    {
        [Key]
        public int TurnoId { get; set; }

        [Required]
        [Display(Name = "Paciente a agendar")]
        public int Id_Paciente { get; set; }

        [Required]
        [Display(Name = "Médico a asignar")]
        public int Id_Medico { get; set; }

        [Required]
        [Display(Name = "Fecha a agendar")]
        public DateOnly FechaTurno { get; set; }

        [Required]
        [Display(Name = "Hora a agendar")]
        public string? HoraTurno { get; set; }

        [DefaultValue(1)]
        public int Estado { get; set; }
    }
}

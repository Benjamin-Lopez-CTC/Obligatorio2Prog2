using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2Prog2.Modelos
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "Es necesario elegir un paciente.")]
        [Display(Name = "Paciente")]
        [ForeignKey(nameof(Paciente))]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Es necesario elegir un medico.")]
        [Display(Name = "Médico")]
        [ForeignKey(nameof(Medico))]
        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Seleccione una fecha.")]
        [Display(Name = "Fecha")]
        public DateOnly FechaTurno { get; set; }

        [DefaultValue(1)]
        [Range(1,3)]
        public int Estado { get; set; } = 1;

        [Required(ErrorMessage = "Seleccione una hora.")]
        [Display(Name = "Hora Del Turno")]
        [ForeignKey(nameof(Hora))]
        public int HoraId { get; set; }
        public Hora? Hora { get; set; }

        [ForeignKey(nameof(Pago))]
        public int PagoId { get; set; } = 0;
        public Pago? Pago { get; set; }
    }
}

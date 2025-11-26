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

        [Required]
        [Display(Name = "Paciente")]
        [ForeignKey(nameof(Paciente))]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Display(Name = "Médico")]
        [ForeignKey(nameof(Medico))]
        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateOnly FechaTurno { get; set; }

        [Required]
        [DefaultValue(1)]
        [Range(1,3)]
        public int Estado { get; set; } = 1;

        [Display(Name = "Hora Del Turno")]
        [ForeignKey(nameof(Hora))]
        public int HoraId { get; set; }
        public Hora? Hora { get; set; }

        [ForeignKey(nameof(Pago))]
        public int? PagoId { get; set; }
        public Pago? Pago { get; set; }
    }
}

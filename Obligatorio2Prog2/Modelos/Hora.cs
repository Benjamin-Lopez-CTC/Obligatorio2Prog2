using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Obligatorio2Prog2.Modelos
{
    public class Hora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoraId { get; set; }

        [Required]
        public string HoraTurno { get; set; }

        [Required]
        [ForeignKey(nameof(Medico))]
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        // Un timeslot puede tener varios turnos (fechas diferentes)
        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}

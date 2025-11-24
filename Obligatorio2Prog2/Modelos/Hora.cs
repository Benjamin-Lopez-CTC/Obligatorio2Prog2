using System.ComponentModel.DataAnnotations;

namespace Obligatorio2Prog2.Modelos
{
    public class Hora
    {
        [Key]
        public int HoraId { get; set; }

        [Required]
        public string HoraTurno { get; set; }

        [Required]
        public string DiaTurno { get; set; }

        [Required]
        public int Id_Paciente { get; set; }

    }
}

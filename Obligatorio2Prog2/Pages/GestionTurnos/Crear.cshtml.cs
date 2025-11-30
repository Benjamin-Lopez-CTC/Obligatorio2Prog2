using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;
using Obligatorio2Prog2.Pages.Estadisticas;

namespace Obligatorio2Prog2.Pages.GestionTurnos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        // Guarda los datos enviados en el formulario en un nuevo objeto turno
        [BindProperty]
        public Turno? Turno { get; set; }

        // Listas de los distintos tipos de objetos para mostrar los datos necesarios en el formulario a modo de dropdown
        public SelectList PacientesSelect { get; set; }
        public SelectList MedicosSelect { get; set; }
        
        public async Task OnGetAsync()
        {
            // Obtiene los pacientes de la base de datos
            var pacientes = await _contexto.Pacientes
                .Select(p => new
                {
                    Id = p.PacienteId,
                    Text = $"{p.NombreP} {p.ApellidoP} ({p.NumDocumentoP})"
                }).ToListAsync();

            PacientesSelect = new SelectList(pacientes, "Id", "Text");

            // Obtiene los medicos de la base de datos a modo de select list para el formulario
            var medicos = await _contexto.Medicos
                .Select(m => new
                {
                    Id = m.MedicoId,
                    Text = $"{m.NombreM} {m.ApellidoM} ({m.MatriculaM})"
                }).ToListAsync();

            MedicosSelect = new SelectList(medicos, "Id", "Text");
        }

        // Extrae solo las horas del medico seleccionado en el formulario, el dropdown se actualizara en tiempo real para no tener que recargar la pagina
        public async Task<JsonResult> OnGetHorasDisponiblesAsync(int medicoId, DateOnly fecha)
        {
            // Obtiene las horas del medico seleccionado
            var horasMedico = _contexto.Horas
                .Where(h => h.MedicoId == medicoId);

            // Obtiene por otro lado las horas que ya estan ocupadas en el dia seleccionado
            var horasAgendadas = _contexto.Turnos
                .Where(t => t.MedicoId == medicoId && t.FechaTurno == fecha)
                .Select(t => t.HoraId);

            // Por ultimo, obtiene las horas disponibles del medico seleccionado utilizando ambas listas filtradas
            var horasDisponibles = await horasMedico
                .Where(h => !horasAgendadas.Contains(h.HoraId))
                .ToListAsync();

            return new JsonResult(horasDisponibles);
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
            // Restriccion a nivel del servidor de la seleccion de la fecha de la consulta, funciona en conjunto con la restriccion a nivel del cliente
            if (Turno.FechaTurno.DayOfWeek == DayOfWeek.Saturday || Turno.FechaTurno.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("Turno.FechaTurno", "Los dias de atención son de lunes a viernes");
            }

            
        }*/
    }
}

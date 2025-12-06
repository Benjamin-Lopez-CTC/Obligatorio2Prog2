using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Pages.Estadisticas
{
    public class TurnosFrecuentesModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public TurnosFrecuentesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<string> Especialidades { get; set; } = new();

        public IEnumerable<Turno> Turnos { get; set; }

        public async Task OnGet()
        {
            Especialidades = _contexto.Medicos
                .Select(m => m.EspecialidadM)
                .Distinct()
                .ToList();

            Turnos = await _contexto.Turnos
                .Include(t => t.Medico)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostOrdenar(string orden)
        {
            //Cargar datos de nuevo
            Especialidades = _contexto.Medicos
                .Select(m => m.EspecialidadM)
                .Distinct()
                .ToList();

            Turnos = await _contexto.Turnos
                .Include(t => t.Medico)
                .ToListAsync();

            //Ordenar según cantidad de turnos
            if (orden == "asc")
            {
                Especialidades = Especialidades.OrderBy(esp => Turnos.Count(t => t.Medico != null && t.Medico.EspecialidadM == esp)).ToList();
            }
            else
            {
                Especialidades = Especialidades.OrderByDescending(esp => Turnos.Count(t => t.Medico != null && t.Medico.EspecialidadM == esp)).ToList();
            }

            return Page();
        }
    }
}

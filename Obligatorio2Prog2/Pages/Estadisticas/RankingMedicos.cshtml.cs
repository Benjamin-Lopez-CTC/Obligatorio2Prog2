using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Pages.Estadisticas
{
    public class RankingMedicosModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public RankingMedicosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Medico> Medicos { get; set; }

        public IEnumerable<Turno> Turnos { get; set; }

        public async Task OnGet()
        {
            Medicos = await _contexto.Medicos.ToListAsync();
            Turnos = await _contexto.Turnos.ToListAsync();
        }


        public async Task<IActionResult> OnPostOrdenar(string orden)
        {
            Turnos = await _contexto.Turnos
                .Include(t => t.Medico)
                .ToListAsync();

            Medicos = await _contexto.Medicos.ToListAsync();

            if (orden == "asc")
            {
                Medicos = Medicos.OrderBy(m => Turnos.Count(t => t.MedicoId == m.MedicoId)).ToList();
            }
            else
            {
                Medicos = Medicos.OrderByDescending(m => Turnos.Count(t => t.MedicoId == m.MedicoId)).ToList();
            }

            return Page();
        }
    }
}


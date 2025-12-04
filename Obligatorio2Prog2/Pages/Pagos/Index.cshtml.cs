using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Pages.Pagos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Turno> Turnos { get; set; }

        //Metodo para traer todos los turnos, pacientes y medicos (con sus horas)
        public async Task OnGetAsync()
        {
            Turnos = await _contexto.Turnos
            .Include(t => t.Paciente)
            .Include(t => t.Medico)
            .ThenInclude(m => m.Horas)
            .Include(t => t.Hora)
            .ToListAsync();
        }
    }
}

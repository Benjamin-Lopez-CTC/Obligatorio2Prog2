using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Obligatorio2Prog2.Pages.GestionTurnos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Turno> Turnos { get; set; }
        public async Task OnGet()
        {
            Turnos = await _contexto.Turnos.ToListAsync();
        }
    }
}
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        //Metodo para traer todos los turnos, pacientes y medicos (con sus horas)
        public async Task OnGet()
        {
            Turnos = await _contexto.Turnos
            .Include(t => t.Paciente)
            .Include(t => t.Medico)
            .ThenInclude(m => m.Horas)
            .Include(t => t.Hora)
            .ToListAsync();
        }

        //Metodo para cancelar turno
        //Se pide el Turnoid
        public async Task<IActionResult> OnPostCancelar(int Turnoid)
        {
            //Se busca un turno con ese id y se guarda en una variable
            var turno = await _contexto.Turnos.FindAsync(Turnoid);
            //Se cambia el estado del turno a 3 (Cancelado)
            turno.Estado = 3;

            //Se guardan los cambios en la BDD
            await _contexto.SaveChangesAsync();

            //Se refresca la pagina
            return RedirectToPage();
        }

        //Metodo para reprogramar un turno
        //Se pide el TurnoId y HoraId
        public async Task<IActionResult> OnPostReprogramar(int TurnoId, int HoraId)
        {
            //Se guarda en una variable turno el turno que tenga el id se envio al metodo
            var turno = await _contexto.Turnos.FindAsync(TurnoId);
            //Se cambia el id de la hora para que se modifique la hora del turno
            turno.HoraId = HoraId;

            //Se guardan los cambios en la BDD
            await _contexto.SaveChangesAsync();

            //Se refresca la pagina
            return RedirectToPage();
        }
    }
}
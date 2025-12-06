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
        // Obtiene los datos del pago introducidos en el formulario
        [BindProperty]
        public Pago? Pago { get; set; }

        // Obtiene el Id del turno al cual se le esta haciendo un pago
        [BindProperty]
        public int TurnoId { get; set; }

        public IEnumerable<Turno> Turnos { get; set; }

        //Metodo para traer todos los turnos, pacientes y medicos (con sus horas)
        public async Task OnGetAsync()
        {
            Turnos = await _contexto.Turnos
            .Include(t => t.Paciente)
            .Include(t => t.Medico).ThenInclude(m => m.Horas)
            .Include(t => t.Hora)
            .Include(t => t.Pago)
            .ToListAsync();
        }

        public async Task<IActionResult> OnPostPagar()
        {   
            if (Pago.MontoPago > 100000)
            {
                ModelState.AddModelError("Pago.MontoPago", "El monto no puede ser mayor a $100.000");
            }

            // Si pago es nulo guarda todos los datos del formulario en turno lo sube a la base de datos, no redirige a ningun lado
            if (Pago == null)
            {
                Pago = new Pago();
            }
            Pago.FechaPago = DateOnly.FromDateTime(DateTime.Now);

            // Elimina cualquier error previo de ModelState para FechaPago y reevalúa
            ModelState.Remove(nameof(Pago) + "." + nameof(Pago.FechaPago));

            // Si toda la validacion del formulario pasa sin problemas
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Encuentra de la base de datos el turno al que se le estaba registrando un pago en el formulario de Index.cshtml
            var turno = await _contexto.Turnos.FindAsync(TurnoId);
            if (turno == null)
            {
                ModelState.AddModelError(string.Empty, "Turno no encontrado.");
                return Page();
            }

            // Añade el pago a la base de datos y le asigna el pagoId al pagoId del turno correspondiente
            _contexto.Pagos.Add(Pago);
            await _contexto.SaveChangesAsync();
            turno.PagoId = Pago.PagoId;
            await _contexto.SaveChangesAsync();
            TempData["ExitoPago"] = "Pago registrado exitosamente!";
            return RedirectToPage();
        }
    }
}

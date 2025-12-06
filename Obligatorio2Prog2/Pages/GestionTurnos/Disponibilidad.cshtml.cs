using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Pages.GestionTurnos
{
    public class DisponibilidadModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public DisponibilidadModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Medico> Medicos { get; set; }

        //Lista con todas las especialidades
        public List<string> Especialidades { get; set; } = new();

        //Guarda en la propiedad Buscar el valor que venga en el formulario
        [BindProperty(SupportsGet = true)]
        public string Buscar { get; set; }

        public async Task OnGet()
        {
            var MedicosDB = _contexto.Medicos
                .Include(m => m.Horas)
                .AsQueryable();

            //Guarda en especialidades cada especialidad de los medicos sin repetir
            Especialidades = await _contexto.Medicos
                .Select(m => m.EspecialidadM)
                .Distinct()
                .ToListAsync();

            // Si hay una busqueda...
            if (!string.IsNullOrWhiteSpace(Buscar))
            {
                Buscar = Buscar.ToLower().Replace(" ", "");

                MedicosDB = MedicosDB.Where(m =>
                    m.NombreM.ToLower().Replace(" ", "").Contains(Buscar) ||
                    m.ApellidoM.ToLower().Replace(" ", "").Contains(Buscar) ||
                    m.MatriculaM.Replace(" ", "").Contains(Buscar));
            }

            //Carga final
            Medicos = await MedicosDB.ToListAsync();
        }


        public async Task<IActionResult> OnPostOrdenar(string especialidad)
        {
            IQueryable<Medico> MedicosDB = _contexto.Medicos.Include(m => m.Horas);

            //Si la opcion elegida no es Mostrar todos muestra solo los medicos que tengan de especialidad la elegida
            if (especialidad != "todos")
            {
                MedicosDB = MedicosDB.Where(m => m.EspecialidadM == especialidad);
            }

            //Si no, los muestra todos
            Medicos = await MedicosDB.ToListAsync();

            //Vuelve a llenar el select con las especialidades
            Especialidades = _contexto.Medicos.Select(m => m.EspecialidadM).Distinct().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostBorrarBusqueda()
        {
            //Prepara una consulta de medicos que se puede filtrar varias veces antes de ejecutarse
            IQueryable<Medico> MedicosDB = _contexto.Medicos.Include(m => m.Horas);
            //Limpia la caja de busqueda
            Buscar = null;
            //Guarda en la lista de Medicos la consulta filtrada
            Medicos = await MedicosDB.ToListAsync();
            Especialidades = _contexto.Medicos.Select(m => m.EspecialidadM).Distinct().ToList();
            return Page();
        }
    }
}

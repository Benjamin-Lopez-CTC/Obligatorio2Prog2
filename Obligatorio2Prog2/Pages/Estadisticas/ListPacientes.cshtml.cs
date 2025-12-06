using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Obligatorio2Prog2.Pages.Estadisticas
{
    public class ListPacientesModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public ListPacientesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Paciente> Pacientes { get; set; }

        //Guarda lo que busca el usuario en la propiedad Buscar
        [BindProperty(SupportsGet = true)]
        public string Buscar { get; set; }

        public async Task OnGet()
        {
            var PacientesDB = _contexto.Pacientes.AsQueryable();

            //Si hay una busqueda...
            if (!string.IsNullOrWhiteSpace(Buscar))
            {
                //Quita los espacios vacios, guiones y puntos (guiones y puntos para la CI)
                Buscar = Buscar.ToLower().Replace(".", "").Replace("-", "").Replace(" ", "");

                //Muestra solo los pacientes que coincidan con la busqueda del usuario
                PacientesDB = PacientesDB.Where(p => p.NombreP.ToLower().Replace(" ", "").Contains(Buscar)
                || p.ApellidoP.ToLower().Replace(" ", "").Contains(Buscar)
                || p.NumDocumentoP.Replace(" ", "").Replace(".", "").Replace("-", "").Contains(Buscar));
            }

            Pacientes = await PacientesDB.ToListAsync();
        }


        public async Task<IActionResult> OnPostOrdenar(string categoria)
        {
            //Prepara una consulta de pacientes que se puede filtrar varias veces antes de ejecutarse
            IQueryable<Paciente> PacientesDB = _contexto.Pacientes;

            //Dependiendo de la opcion elegida es como se filtrara la lista de pacientes.
            if (categoria == "NombreP")
            {
                PacientesDB = PacientesDB.OrderBy(p => p.NombreP);
            }

            else if (categoria == "NombrePDesc")
            {
                PacientesDB = PacientesDB.OrderByDescending(p => p.NombreP);
            }

            else if (categoria == "ApellidoP")
            {
                PacientesDB = PacientesDB.OrderBy(p => p.ApellidoP);
            }

            else if (categoria == "ApellidoPDesc")
            {
                PacientesDB = PacientesDB.OrderByDescending(p => p.ApellidoP);
            }

            //Guarda en la lista de Pacientes la consulta filtrada
            Pacientes = await PacientesDB.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostBorrarBusqueda()
        {
            //Prepara una consulta de pacientes que se puede filtrar varias veces antes de ejecutarse
            IQueryable<Paciente> PacientesDB = _contexto.Pacientes;
            //Limpia la caja de busqueda
            Buscar = null;
            //Guarda en la lista de Pacientes la consulta filtrada
            Pacientes = await PacientesDB.ToListAsync();

            return Page();
        }
    }
}

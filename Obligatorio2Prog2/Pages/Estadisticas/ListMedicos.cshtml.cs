using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Datos;
using Obligatorio2Prog2.Modelos;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Obligatorio2Prog2.Pages.Estadisticas
{
    public class ListMedicosModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public ListMedicosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Medico> Medicos { get; set; }

        //Lista con todas las especialidades
        public List<string> Especialidades { get; set; }

        //Guarda en la propiedad Buscar el valor que venga en el formulario
        [BindProperty(SupportsGet = true)]
        public string Buscar { get; set; }

        public async Task OnGet()
        {
            var MedicosDB = _contexto.Medicos.AsQueryable();
            //Guarda en especialidades cada especialidad de los medicos sin repetir
            Especialidades = _contexto.Medicos.Select(m => m.EspecialidadM).Distinct().ToList();

            //Si hay un busqueda...
            if (!string.IsNullOrWhiteSpace(Buscar))
            {
                //Quita los espacios vacios
                Buscar = Buscar.ToLower().Replace(" ", "");

                //Muestra solo los medicos que coincidan con la busqueda
                MedicosDB = MedicosDB.Where(m => m.NombreM.ToLower().Replace(" ", "").Contains(Buscar)
                || m.ApellidoM.ToLower().Replace(" ", "").Contains(Buscar)
                || m.MatriculaM.Replace(" ", "").Contains(Buscar));
            }

            //Guarda los medicos para que se muestren.
            Medicos = await MedicosDB.ToListAsync();
        }


        public async Task<IActionResult> OnPostOrdenar(string especialidad)
        {
            IQueryable<Medico> MedicosDB = _contexto.Medicos;


            //OPCION PARA MOSTRAR TODOS LOS MEDICOS A LA HORA DE FILTRAR PERO PRIMERO LOS QUE TENGAN LA ESPECIALIDAD ELEGIDA
            //MedicosDB = MedicosDB.OrderByDescending(m => m.EspecialidadM == especialidad);

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

    }
}

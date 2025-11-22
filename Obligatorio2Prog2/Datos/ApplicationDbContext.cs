using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Modelos
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Hora> Horas { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Turno> Turnos { get; set; }

    }
}

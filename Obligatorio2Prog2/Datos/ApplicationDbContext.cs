using Microsoft.EntityFrameworkCore;
using Obligatorio2Prog2.Modelos;

namespace Obligatorio2Prog2.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Hora> Horas { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Medico -> Horas (mantener Cascade si borrar médico debe eliminar timeslots)
            modelBuilder.Entity<Hora>()
                .HasOne(h => h.Medico)
                .WithMany(m => m.Horas)
                .HasForeignKey(h => h.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Medico -> Turnos : NO ACTION/RESTRICT para evitar multiple cascade paths
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany(m => m.Turnos)
                .HasForeignKey(t => t.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);

            // Hora -> Turnos : evitar cascada desde Hora a Turnos si hay otra ruta
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Hora)
                .WithMany(h => h.Turnos)
                .HasForeignKey(t => t.HoraId)
                .OnDelete(DeleteBehavior.Restrict);

            // Paciente -> Turnos : normalmente Cascade (o NoAction según reglas de negocio)
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Turno -> Pago : uno a uno con FK por defecto 0
            modelBuilder.Entity<Turno>()
                .Property(t => t.PagoId)
                .HasDefaultValue(0)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

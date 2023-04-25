using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LABMedicine.Models
{
    public class LabMedicineBdContext : DbContext
    {
        public LabMedicineBdContext(DbContextOptions<LabMedicineBdContext> options) : base(options) 
        { 
        }
        public DbSet <EnfermeiroModel> Enfermeiros { get; set; }
        public DbSet <MedicoModel> Medicos { get; set; }

        public DbSet <PacienteModel> Pacientes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<PacienteModel>().HasData
            (new PacienteModel
            {
                Id = 1,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino"

            },
            new PacienteModel
            {
                Id = 2,
            }
            );
        }
     }
}

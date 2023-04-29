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
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 2,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 3,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 4,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 5,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 6,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 7,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 8,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 9,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new PacienteModel
            {
                Id = 10,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            }
            );

            modelBuilder.Entity<MedicoModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<MedicoModel>().HasData
            (new MedicoModel
            {
                Id = 11,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new MedicoModel
            {
                Id = 12,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            }
            );

            modelBuilder.Entity<EnfermeiroModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<EnfermeiroModel>().HasData
            (new EnfermeiroModel
            {
                Id = 13,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            },
            new EnfermeiroModel
            {
                Id = 14,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442"
            }
            );
        }
     }
}

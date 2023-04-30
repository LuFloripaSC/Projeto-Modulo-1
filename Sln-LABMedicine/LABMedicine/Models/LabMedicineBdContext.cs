using LABMedicine.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LABMedicine.Models
{
    public class LabMedicineBdContext : DbContext
    {
        public LabMedicineBdContext(DbContextOptions<LabMedicineBdContext> options) : base(options)
        {
        }
        public DbSet<EnfermeiroModel> Enfermeiros { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }

        public DbSet<PacienteModel> Pacientes { get; set;}

        public DbSet<AtendimentoModel> Atendimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteModel>().Property(x => x.Alergias).HasConversion(c => string.Join(',', c), c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()).Metadata.SetValueComparer(new ListValueComparer());

            modelBuilder.Entity<PacienteModel>().Property(x => x.CuidadosEspecificos).HasConversion(c => string.Join(',', c), c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()).Metadata.SetValueComparer(new ListValueComparer());

            modelBuilder.Entity<PacienteModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<PacienteModel>().HasData
            (new PacienteModel
            {
                Id = 1,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "880.875.680-79",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() {"camarão","leite"},
                CuidadosEspecificos = new List<string>() {"Comida com pouco sal"}
                

            },
            new PacienteModel
            {   
                Id= 2,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "257.681.760-20",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 3,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "820.383.680-15",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 4,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "503.319.910-20",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 5,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "211.570.090-26",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 6,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "102.921.930-33",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 7,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "600.030.830-20",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 8,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "540.365.260-49",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 9,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "896.203.500-65",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            },
            new PacienteModel
            {
                Id= 10,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "944.482.430-60",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() { "camarão", "leite" },
                CuidadosEspecificos = new List<string>() { "Comida com pouco sal" }
            }
            ) ;

            modelBuilder.Entity<MedicoModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<MedicoModel>().HasData
            (new MedicoModel
            {    
                Id = 11,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "789.498.200-80",
                Telefone = "48 999323442",
                CRM = "34442",
                Ensino = "Escola de Medicina",
                Especializacao = Enumerator.EnumEspecializacaoClinica.Dermatologista
            },
            new MedicoModel
            {
                Id = 12,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "770.908.920-85",
                Telefone = "48 999323442",
                CRM = "5885493",
                Ensino = "Escola de Medicina",
                Especializacao = Enumerator.EnumEspecializacaoClinica.ClinicoGeral

            }
            );

            modelBuilder.Entity<EnfermeiroModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<EnfermeiroModel>().HasData
            (new EnfermeiroModel
            {
                Id= 13,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "129.809.060-18",
                Telefone = "48 999323442",
                Cofen = "49894u92",
                EnsinoEnfermeiro = "Escola de Enfermagem"
            },
            new EnfermeiroModel
            {
                Id= 14,
                NomeCompleto = "Luciano Stucker",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "308.859.180-02",
                Telefone = "48 999323442",
                Cofen = "849829498",
                EnsinoEnfermeiro = "Escola de Enfermagem"
            }
            );
        }
     }
}

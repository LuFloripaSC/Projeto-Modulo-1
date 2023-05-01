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
                NomeCompleto = "Renato Souza",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("13/02/97"),
                CPF = "257.681.760-20",
                Telefone = "48 9995878442",
                TelEmergencia = "48 5432344334",
                Alergias = new List<string>() {"queijo"},
                CuidadosEspecificos = new List<string>() {"Evitar esforço fisico"}
            },
            new PacienteModel
            {
                Id= 3,
                NomeCompleto = "Fernanda Almeida",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("19/06/87"),
                CPF = "820.383.680-15",
                Telefone = "48 999323442",
                TelEmergencia = "48 54344334",
                Alergias = new List<string>() {"camarão", "leite"},
                CuidadosEspecificos = new List<string>() {"Toma rémdio para pressão alta"}
            },
            new PacienteModel
            {
                Id= 4,
                NomeCompleto = "Maria Antonieta",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("27/04/67"),
                CPF = "503.319.910-20",
                Telefone = "47 993493234",
                TelEmergencia = "48 543456224",
                Alergias = new List<string>() {},
                CuidadosEspecificos = new List<string>() {"Alergia ao alcool"}
            },
            new PacienteModel
            {
                Id= 5,
                NomeCompleto = "Rogerio Sampaio",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("07/10/72"),
                CPF = "211.570.090-26",
                Telefone = "47 9231323442",
                TelEmergencia = "48 9598344334",
                Alergias = new List<string>() {},
                CuidadosEspecificos = new List<string>() {}
            },
            new PacienteModel
            {
                Id= 6,
                NomeCompleto = "Claudia Silva",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "102.921.930-33",
                Telefone = "42 9969323442",
                TelEmergencia = "48 357834334",
                Alergias = new List<string>() {},
                CuidadosEspecificos = new List<string>() {}
            },
            new PacienteModel
            {
                Id= 7,
                NomeCompleto = "Rafael Antunes",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("21/04/47"),
                CPF = "600.030.830-20",
                Telefone = "48 989667776",
                TelEmergencia = "48 356344334",
                Alergias = new List<string>() {"corantes", "leite"},
                CuidadosEspecificos = new List<string>() {"Tratamento para leucemia"}
            },
            new PacienteModel
            {
                Id= 8,
                NomeCompleto = "Raquel Schmidt",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "540.365.260-49",
                Telefone = "48 9911123442",
                TelEmergencia = "48 354905334",
                Alergias = new List<string>() {},
                CuidadosEspecificos = new List<string>() {}
            },
            new PacienteModel
            {
                Id= 9,
                NomeCompleto = "João da Silva",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "896.203.500-65",
                Telefone = "48 9358893442",
                TelEmergencia = "48 904522034",
                Alergias = new List<string>() {"camarão"},
                CuidadosEspecificos = new List<string>() {"Enfartado"}
            },
            new PacienteModel
            {
                Id= 10,
                NomeCompleto = "Leticia Ramos",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("17/04/77"),
                CPF = "944.482.430-60",
                Telefone = "48 937753442",
                TelEmergencia = "47 904432134",
                Alergias = new List<string>() {},
                CuidadosEspecificos = new List<string>() {"Gestante"}
            }
            ) ;

            modelBuilder.Entity<MedicoModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<MedicoModel>().HasData
            (new MedicoModel
            {    
                Id = 11,
                NomeCompleto = "Gerson Cavalcante",
                Genero = "Masculino",
                DataNascimento = DateTime.Parse("29/11/87"),
                CPF = "789.498.200-80",
                Telefone = "48 900023442",
                CRM = "33442",
                Ensino = "Escola Superior de Medicina",
                Especializacao = Enumerator.EnumEspecializacaoClinica.Dermatologista
            },
            new MedicoModel
            {
                Id = 12,
                NomeCompleto = "Regina Magalhaes",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("19/08/47"),
                CPF = "770.908.920-85",
                Telefone = "48 997773442",
                CRM = "5885493",
                Ensino = "Faculdade Superior de Medicina",
                Especializacao = Enumerator.EnumEspecializacaoClinica.ClinicoGeral

            }
            );

            modelBuilder.Entity<EnfermeiroModel>().HasIndex(p => new { p.CPF }).IsUnique(true);
            modelBuilder.Entity<EnfermeiroModel>().HasData
            (new EnfermeiroModel
            {
                Id= 13,
                NomeCompleto = "Aline Carvalho",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("10/07/77"),
                CPF = "129.809.060-18",
                Telefone = "48 949953442",
                Cofen = "432292",
                EnsinoEnfermeiro = "Escola de Enfermagem"
            },
            new EnfermeiroModel
            {
                Id= 14,
                NomeCompleto = "Maria Regina Soares",
                Genero = "Feminino",
                DataNascimento = DateTime.Parse("12/03/79"),
                CPF = "308.859.180-02",
                Telefone = "48 998323442",
                Cofen = "849829498",
                EnsinoEnfermeiro = "Escola de Enfermagem"
            }
            );
        }
     }
}

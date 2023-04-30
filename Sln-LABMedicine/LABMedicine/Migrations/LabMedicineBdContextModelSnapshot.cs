﻿// <auto-generated />
using System;
using LABMedicine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LABMedicine.Migrations
{
    [DbContext(typeof(LabMedicineBdContext))]
    partial class LabMedicineBdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LABMedicine.Models.AtendimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoAtendimento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO ATENDIMENTO");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int")
                        .HasColumnName("ID MEDICO");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("ID PACIENTE");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("LABMedicine.Models.EnfermeiroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("Cofen")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("COFEN/UF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA DE NASCIMENTO");

                    b.Property<string>("EnsinoEnfermeiro")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("INSTITUICAO DE ENSINO");

                    b.Property<string>("Genero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GENERO");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NOME COMPLETO");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[CPF] IS NOT NULL");

                    b.ToTable("Enfermeiro");

                    b.HasData(
                        new
                        {
                            Id = 13,
                            CPF = "129.809.060-18",
                            Cofen = "49894u92",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnsinoEnfermeiro = "Escola de Enfermagem",
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Telefone = "48 999323442"
                        },
                        new
                        {
                            Id = 14,
                            CPF = "308.859.180-02",
                            Cofen = "849829498",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnsinoEnfermeiro = "Escola de Enfermagem",
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Telefone = "48 999323442"
                        });
                });

            modelBuilder.Entity("LABMedicine.Models.MedicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtendimentosRealizados")
                        .HasColumnType("int")
                        .HasColumnName("ATENDIMENTOS REALIZADOS");

                    b.Property<string>("CPF")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CRM/UF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA DE NASCIMENTO");

                    b.Property<string>("Ensino")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("INSTITUICAO DE ENSINO");

                    b.Property<int>("Especializacao")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("ESPECIALIZACAO");

                    b.Property<int>("EstadoNoSistema")
                        .HasColumnType("int")
                        .HasColumnName("STATUS DO SISTEMA");

                    b.Property<string>("Genero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GENERO");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NOME COMPLETO");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[CPF] IS NOT NULL");

                    b.ToTable("Medico");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            AtendimentosRealizados = 0,
                            CPF = "789.498.200-80",
                            CRM = "34442",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ensino = "Escola de Medicina",
                            Especializacao = 2,
                            EstadoNoSistema = 0,
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Telefone = "48 999323442"
                        },
                        new
                        {
                            Id = 12,
                            AtendimentosRealizados = 0,
                            CPF = "770.908.920-85",
                            CRM = "5885493",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ensino = "Escola de Medicina",
                            Especializacao = 0,
                            EstadoNoSistema = 0,
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Telefone = "48 999323442"
                        });
                });

            modelBuilder.Entity("LABMedicine.Models.PacienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alergias")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ALERGIAS");

                    b.Property<string>("CPF")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CPF");

                    b.Property<string>("Convenio")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CONVENIO");

                    b.Property<string>("CuidadosEspecificos")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CUIDADOS ESPECIFICOS");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA DE NASCIMENTO");

                    b.Property<string>("Genero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("GENERO");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NOME COMPLETO");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS DE ATENDIMENTO");

                    b.Property<string>("TelEmergencia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TEL EMERGENCIA");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TELEFONE");

                    b.Property<int>("TotalAtendimentos")
                        .HasColumnType("int")
                        .HasColumnName(" TOTAL DE ATENDIMENTOS");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[CPF] IS NOT NULL");

                    b.ToTable("Paciente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alergias = "camarão,leite",
                            CPF = "880.875.680-79",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 2,
                            Alergias = "camarão,leite",
                            CPF = "257.681.760-20",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 3,
                            Alergias = "camarão,leite",
                            CPF = "820.383.680-15",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 4,
                            Alergias = "camarão,leite",
                            CPF = "503.319.910-20",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 5,
                            Alergias = "camarão,leite",
                            CPF = "211.570.090-26",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 6,
                            Alergias = "camarão,leite",
                            CPF = "102.921.930-33",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 7,
                            Alergias = "camarão,leite",
                            CPF = "600.030.830-20",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 8,
                            Alergias = "camarão,leite",
                            CPF = "540.365.260-49",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 9,
                            Alergias = "camarão,leite",
                            CPF = "896.203.500-65",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        },
                        new
                        {
                            Id = 10,
                            Alergias = "camarão,leite",
                            CPF = "944.482.430-60",
                            CuidadosEspecificos = "Comida com pouco sal",
                            DataNascimento = new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            NomeCompleto = "Luciano Stucker",
                            Status = 0,
                            TelEmergencia = "48 54344334",
                            Telefone = "48 999323442",
                            TotalAtendimentos = 0
                        });
                });

            modelBuilder.Entity("LABMedicine.Models.AtendimentoModel", b =>
                {
                    b.HasOne("LABMedicine.Models.MedicoModel", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId");

                    b.HasOne("LABMedicine.Models.PacienteModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}

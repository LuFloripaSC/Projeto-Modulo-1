using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABMedicine.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSTITUICAODEENSINO = table.Column<string>(name: "INSTITUICAO DE ENSINO", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    COFENUF = table.Column<string>(name: "COFEN/UF", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NOMECOMPLETO = table.Column<string>(name: "NOME COMPLETO", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GENERO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DATADENASCIMENTO = table.Column<DateTime>(name: "DATA DE NASCIMENTO", type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSTITUICAODEENSINO = table.Column<string>(name: "INSTITUICAO DE ENSINO", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CRMUF = table.Column<string>(name: "CRM/UF", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ESPECIALIZACAO = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    STATUSDOSISTEMA = table.Column<int>(name: "STATUS DO SISTEMA", type: "int", nullable: false),
                    ATENDIMENTOSREALIZADOS = table.Column<int>(name: "ATENDIMENTOS REALIZADOS", type: "int", nullable: false),
                    NOMECOMPLETO = table.Column<string>(name: "NOME COMPLETO", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GENERO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DATADENASCIMENTO = table.Column<DateTime>(name: "DATA DE NASCIMENTO", type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TELEMERGENCIA = table.Column<string>(name: "TEL EMERGENCIA", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ALERGIAS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CUIDADOSESPECIFICOS = table.Column<string>(name: "CUIDADOS ESPECIFICOS", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONVENIO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    STATUSDEATENDIMENTO = table.Column<int>(name: "STATUS DE ATENDIMENTO", type: "int", nullable: false),
                    TOTALDEATENDIMENTOS = table.Column<int>(name: " TOTAL DE ATENDIMENTOS", type: "int", nullable: false),
                    NOMECOMPLETO = table.Column<string>(name: "NOME COMPLETO", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GENERO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DATADENASCIMENTO = table.Column<DateTime>(name: "DATA DE NASCIMENTO", type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMEDICO = table.Column<int>(name: "ID MEDICO", type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    IDPACIENTE = table.Column<int>(name: "ID PACIENTE", type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    DESCRICAOATENDIMENTO = table.Column<string>(name: "DESCRICAO ATENDIMENTO", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atendimento_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Atendimento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Enfermeiro",
                columns: new[] { "ID", "CPF", "COFEN/UF", "DATA DE NASCIMENTO", "INSTITUICAO DE ENSINO", "GENERO", "NOME COMPLETO", "TELEFONE" },
                values: new object[,]
                {
                    { 13, "129.809.060-18", "49894u92", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola de Enfermagem", "Masculino", "Luciano Stucker", "48 999323442" },
                    { 14, "308.859.180-02", "849829498", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola de Enfermagem", "Masculino", "Luciano Stucker", "48 999323442" }
                });

            migrationBuilder.InsertData(
                table: "Medico",
                columns: new[] { "ID", "ATENDIMENTOS REALIZADOS", "CPF", "CRM/UF", "DATA DE NASCIMENTO", "INSTITUICAO DE ENSINO", "ESPECIALIZACAO", "STATUS DO SISTEMA", "GENERO", "NOME COMPLETO", "TELEFONE" },
                values: new object[,]
                {
                    { 11, 0, "789.498.200-80", "34442", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola de Medicina", 2, 0, "Masculino", "Luciano Stucker", "48 999323442" },
                    { 12, 0, "770.908.920-85", "5885493", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola de Medicina", 0, 0, "Masculino", "Luciano Stucker", "48 999323442" }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "ID", "ALERGIAS", "CPF", "CONVENIO", "CUIDADOS ESPECIFICOS", "DATA DE NASCIMENTO", "GENERO", "NOME COMPLETO", "STATUS DE ATENDIMENTO", "TEL EMERGENCIA", "TELEFONE", " TOTAL DE ATENDIMENTOS" },
                values: new object[,]
                {
                    { 1, "camarão,leite", "880.875.680-79", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 2, "camarão,leite", "257.681.760-20", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 3, "camarão,leite", "820.383.680-15", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 4, "camarão,leite", "503.319.910-20", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 5, "camarão,leite", "211.570.090-26", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 6, "camarão,leite", "102.921.930-33", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 7, "camarão,leite", "600.030.830-20", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 8, "camarão,leite", "540.365.260-49", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 9, "camarão,leite", "896.203.500-65", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 },
                    { 10, "camarão,leite", "944.482.430-60", null, "Comida com pouco sal", new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luciano Stucker", 0, "48 54344334", "48 999323442", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MedicoId",
                table: "Atendimento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                table: "Atendimento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiro_CPF",
                table: "Enfermeiro",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CPF",
                table: "Medico",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Enfermeiro");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}

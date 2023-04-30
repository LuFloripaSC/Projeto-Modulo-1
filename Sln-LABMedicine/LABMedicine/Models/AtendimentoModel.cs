using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.Models
{
    [Table("Atendimento")]
    public class AtendimentoModel
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ID MEDICO")]
        [ForeignKey("MedicoModel")]
        public int IdMedico { get; set; }
        public MedicoModel Medico { get; set; } = new MedicoModel();

        [Column("ID PACIENTE")]
        [ForeignKey("PacienteModel")]
        public int IdPaciente { get; set; }
        public PacienteModel Paciente { get; set; } = new PacienteModel();

        [Column("DESCRICAO ATENDIMENTO")]
        [AllowNull]
        public string DescricaoAtendimento { get; set; }

    }
}

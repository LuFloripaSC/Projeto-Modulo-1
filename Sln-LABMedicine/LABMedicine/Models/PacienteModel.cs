using LABMedicine.Base;
using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.Models
{
    [Table("Paciente")]
    public class PacienteModel : Pessoa
    {
        [Required]
        [Column("TEL EMERGENCIA"), MaxLength(20)]
        public string TelEmergencia { get; set; }

        [AllowNull]
        [Column("ALERGIAS"), MaxLength(20)]
        public List<string> Alergias { get; set; }

        [AllowNull]
        [Column("CUIDADOS ESPECIFICOS"), MaxLength (50)]
        public List<string> CuidadosEspecificos { get; set;}

        [AllowNull]
        [Column("CONVENIO"), MaxLength(20)]
        public string Convenio { get; set;}

        [Column("STATUS DE ATENDIMENTO")]
        public EnumStatusAtendimento Status { get; set; }

        [AllowNull]
        [Column(" TOTAL DE ATENDIMENTOS")]
        public int TotalAtendimentos { get; set; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.Base
{
    public abstract class Pessoa
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("NOME COMPLETO"), MaxLength(30)]
        public string NomeCompleto { get; set; }

        [Column("GENERO"), MaxLength(10)]
        public string Genero { get; set; }

        [Required]
        [Column("DATA DE NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("CPF"), MaxLength(15)]
        public string CPF { get; set; }

        [Column("TELEFONE"), MaxLength(15)]
        public string Telefone { get; set; }
    }
}

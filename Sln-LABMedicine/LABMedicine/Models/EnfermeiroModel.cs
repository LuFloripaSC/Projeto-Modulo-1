using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Base;

namespace LABMedicine.Models
{
    [Table("Enfermeiro")]
    public class EnfermeiroModel : Pessoa 
    {
        [Required]
        [Column("INSTITUICAO DE ENSINO"), MaxLength(40)]
        public string EnsinoEnfermeiro { get; set; }

        [Required]
        [Column("COFEN/UF"), MaxLength(10)]
        public string Cofen { get; set; }
    }
}

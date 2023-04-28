using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.DTOs
{
    public class PessoaUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public string NomeCompleto { get; set; }

        [StringLength(15)]
        public string Genero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]

        [AllowNull]
        public string Telefone { get; set; }
    }
}

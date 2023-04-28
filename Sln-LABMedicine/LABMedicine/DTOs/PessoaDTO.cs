using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.DTOs
{
    public abstract class PessoaDTO
    {
        [Required]
        [StringLength(50)]
        public string NomeCompleto { get; set; }

        [StringLength(15)]
        public string Genero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(15)]
        public string CPF { get; set; }

        [AllowNull]
        public string Telefone { get; set; }

    }
}

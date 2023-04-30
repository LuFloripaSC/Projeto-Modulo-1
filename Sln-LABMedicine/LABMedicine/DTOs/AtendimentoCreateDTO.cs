using LABMedicine.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.DTOs
{
    public class AtendimentoCreateDTO
    {
        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        public string DescricaoAtendimento { get; set; }
    }
}

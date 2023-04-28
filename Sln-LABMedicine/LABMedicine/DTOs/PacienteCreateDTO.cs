using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTOs
{
    public abstract class PacienteCreateDTO : PessoaDTO
    {
        [StringLength(20)]
        public string TelEmergencia { get; set; }

        [StringLength(30)]
        public List<string> Alergias { get; set; }

        [StringLength(100)]
        public List<string> CuidadosEspecificos { get; set; }

        [StringLength(20)]
        public string Convenio { get; set; }

        [Required]
        public string StatusAtendimento { get; set; }

    }
}

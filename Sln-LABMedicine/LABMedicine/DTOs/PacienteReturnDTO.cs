using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using static LABMedicine.Base.ValidacaoCustomizada;
using System.Text.Json.Serialization;

namespace LABMedicine.DTOs
{
    public class PacienteReturnDTO : PessoaDTO
    {
        [Required]
        public int intentificador { get; set; }

        [StringLength(20)]
        public string TelEmergencia { get; set; }

        [StringLength(30)]
        public List<string> Alergias { get; set; }

        [StringLength(100)]
        public List<string> CuidadosEspecificos { get; set; }

        [StringLength(20)]
        public string Convenio { get; set; }

        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public EnumStatusAtendimento StatusAtendimento { get; set; }

        [Required]
        public int TotalAtendimentos { get; set; }

    }

}

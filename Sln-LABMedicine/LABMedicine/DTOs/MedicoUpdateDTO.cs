using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static LABMedicine.Base.ValidacaoCustomizada;
using System.Text.Json.Serialization;

namespace LABMedicine.DTOs
{
    public class MedicoUpdateDTO : PessoaUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public string InstituicaoEnsino { get; set; }

        [Required]
        [StringLength(20)]
        public string CRMUF { get; set; }

        [JsonConverter(typeof(EspecializacaoClinicaConverter))]
        public EnumEspecializacaoClinica EspecializacaoClinica { get; set; }

        [JsonConverter(typeof(EstadoNoSistemaConverter))]
        public EnumEstadoNoSistema SituacaoSistema { get; set; }

        [AllowNull]
        public int TotalAtendimentos { get; set; }
    }
}

using LABMedicine.Enumerator;
using static LABMedicine.Base.ValidacaoCustomizada;
using System.Text.Json.Serialization;

namespace LABMedicine.DTOs
{
    public class PacienteEstadoNoSistemaDTO
    {
        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public EnumStatusAtendimento? StatusAtendimento { get; set; }
    }
}

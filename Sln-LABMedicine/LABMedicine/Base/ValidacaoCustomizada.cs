using System.Text.Json.Serialization;
using System.Text.Json;
using LABMedicine.Enumerator;

namespace LABMedicine.Base
{
    public partial class ValidacaoCustomizada
    {
        public sealed class EstadoNoSistemaConverter : JsonConverter<EnumEstadoNoSistema>
        {
            public override EnumEstadoNoSistema Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<EnumEstadoNoSistema>(value, out var result))
                    throw new JsonException($"Situação Inválida, informe novo valor: {string.Join(",", Enum.GetNames(typeof(EnumEstadoNoSistema)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, EnumEstadoNoSistema value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }

        public sealed class EspecializacaoClinicaConverter : JsonConverter<EnumEspecializacaoClinica>
        {
            public override EnumEspecializacaoClinica Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<EnumEspecializacaoClinica>(value, out var result))
                    throw new JsonException($"Especialização Inválida, informe nova especialização: {string.Join(",", Enum.GetNames(typeof(EnumEspecializacaoClinica)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, EnumEspecializacaoClinica value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }

        public sealed class StatusAtendimentoConverter : JsonConverter<EnumStatusAtendimento>
        {
            public override EnumStatusAtendimento Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<EnumStatusAtendimento>(value, out var result))
                    throw new JsonException($"Status de atendimento Inválido, informe novo: {string.Join(",", Enum.GetNames(typeof(EnumStatusAtendimento)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, EnumStatusAtendimento value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
    }
}

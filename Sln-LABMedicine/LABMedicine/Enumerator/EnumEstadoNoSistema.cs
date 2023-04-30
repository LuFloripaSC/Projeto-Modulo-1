using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumEstadoNoSistema
    {
        Ativo = 0,
        Inativo = 1
    }
}

using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumStatusAtendimento
    {
        AguardandoAtendimento = 0,
        EmAtendimento = 1,
        Atendido = 2,
        NaoAtendido = 3
    }
}

using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumEspecializacaoClinica
    {
        ClinicoGeral = 0,
        Anestesista = 1,
        Dermatologista = 2,
        Ginecologista = 3,
        Neurologista = 4,
        Pediatria = 5,
        Psiquiatria = 6,
        Ortopedia = 7
    }
}

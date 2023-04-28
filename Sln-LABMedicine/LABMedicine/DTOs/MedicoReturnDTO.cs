using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.DTOs
{
    public class MedicoReturnDTO : PessoaDTO
    {
        [Required]
        public int intentificador { get; set; }

        [Required]
        [StringLength(100)]
        public string InstituicaoEnsino { get; set; }

        [Required]
        [StringLength(20)]
        public string CRMUF { get; set; }

        [Required]
        [CheckEspecializacaoClinica(AllowEspecializacoes = "Clinico Geral, Anestesita, Dermatologia, Ginecologia, Neurologia, Pediatria,Psiquiatria,Ortopedia")]
        public string EspecializacaoClinica { get; set; }

        [Required]
        [CheckSituacao(AllowSituacoes = "Ativo,Inativo")]
        public string SituacaoSistema { get; set; }

        [AllowNull]
        public int TotalAtendimentos { get; set; }
    }
}

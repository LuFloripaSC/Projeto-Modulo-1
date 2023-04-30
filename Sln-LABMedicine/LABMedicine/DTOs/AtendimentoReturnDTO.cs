using LABMedicine.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.DTOs
{
    public class AtendimentoReturnDTO
    {
        public MedicoModel Medico { get; set; } = new MedicoModel();

        public PacienteModel Paciente { get; set; } = new PacienteModel();

        public string DescricaoAtendimento { get; set; }
    }
}

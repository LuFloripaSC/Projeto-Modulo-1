using LABMedicine.DTOs;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly LabMedicineBdContext _labMedicineBdContext;

        public AtendimentoController(LabMedicineBdContext labMedicineBdContext)
        {
            _labMedicineBdContext = labMedicineBdContext;
        }

        [HttpPut("/atendimentos")]
        public ActionResult<AtendimentoReturnDTO> Put(AtendimentoCreateDTO atendimentoDTO)
        {
            try
            {
                //Verificar se existe o medico no banco de dados
                var medicoModel = _labMedicineBdContext.Medicos.Where(x => x.Id == atendimentoDTO.IdMedico).FirstOrDefault();
                //se nao existir, retorna que nao encontrou e termina aqui a rotina
                if (medicoModel == null)
                    return StatusCode(404, "Medico não encontrado com o identificador informado.");

                var pacienteModel = _labMedicineBdContext.Pacientes.Where(x => x.Id == atendimentoDTO.IdPaciente).FirstOrDefault();
                //se nao existir, retorna que nao encontrou e termina aqui a rotina
                if (pacienteModel == null)
                    return StatusCode(404, "Paciente não encontrado com o identificador informado.");

                pacienteModel.Status = Enumerator.EnumStatusAtendimento.Atendido;

                pacienteModel.TotalAtendimentos += 1;

                medicoModel.AtendimentosRealizados += 1;

                //Atualiza no banco
                _labMedicineBdContext.Medicos.Attach(medicoModel);

                _labMedicineBdContext.Pacientes.Attach(pacienteModel);

                AtendimentoModel atendimentoModel = new AtendimentoModel();

                atendimentoModel.IdMedico = atendimentoDTO.IdMedico;
                atendimentoModel.IdPaciente = atendimentoDTO.IdPaciente;
                atendimentoModel.DescricaoAtendimento = atendimentoDTO.DescricaoAtendimento;
                atendimentoModel.Medico = medicoModel;
                atendimentoModel.Paciente = pacienteModel;

                _labMedicineBdContext.Atendimentos.Attach(atendimentoModel);

                //Salvar no banco de dados
                _labMedicineBdContext.SaveChanges();

                AtendimentoReturnDTO atendimentoReturnDTO = new AtendimentoReturnDTO();
                atendimentoReturnDTO.Medico = medicoModel;
                atendimentoReturnDTO.Paciente = pacienteModel;
                atendimentoReturnDTO.DescricaoAtendimento = atendimentoDTO.DescricaoAtendimento;

                return StatusCode(200, atendimentoReturnDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }
    }
}

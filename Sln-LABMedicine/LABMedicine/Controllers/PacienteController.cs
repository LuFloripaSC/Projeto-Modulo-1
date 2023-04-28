using LABMedicine.DTOs;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly LabMedicineBdContext _labMedicineBdContext;

        //Construtor com parametro (Injetado)   
        public PacienteController(LabMedicineBdContext labMedicineBdContext) => _labMedicineBdContext = labMedicineBdContext;

        [HttpPost("/pacientes")]
        public ActionResult<PacienteCreateDTO> Post([FromBody] PacienteCreateDTO pacienteDTO)
        {

            try //tente fazer tudo que ta abaixo entre as chaves
            {
                //se alguma coisa der errado aqui, entao para tudo e executa o catch..

                PacienteModel pacienteModel; //Classe referenciada                
                pacienteModel = new PacienteModel(); //Objeto pacienteModel; new = instancia

                pacienteModel.NomeCompleto = pacienteDTO.NomeCompleto;
                pacienteModel.CPF = pacienteDTO.CPF;
                pacienteModel.TelEmergencia = pacienteDTO.TelEmergencia;
                pacienteModel.Cuidados = pacienteDTO.CuidadosEspecificos;
                pacienteModel.Alergias = pacienteDTO.Alergias;
                pacienteModel.DateNascimento = pacienteDTO.DataNascimento;
                pacienteModel.Convenio = pacienteDTO.Convenio;
                pacienteModel.Genero = pacienteDTO.Genero;
                pacienteModel.Telefone = pacienteDTO.Telefone;

                var resultadoDaConsulta = _labMedicineBdContext.Pacientes.Where(ttt => ttt.CPF == pacienteModel.CPF).FirstOrDefault();
                if (resultadoDaConsulta != null)
                {
                    return StatusCode(409, "CPF informado já existe no cadastro.");
                }

                //se o codigo passar por aqui, insere no banco, pq o CPF nao existe la.
                _labMedicineBdContext.Pacientes.Add(pacienteModel);

                //Salva essa altearção no banco
                _labMedicineBdContext.SaveChanges();

                //Cria o objeto DTO e alimenta pra retornar ao usuario na tela
                PacienteResponseDTO pacienteResponseDTO = new PacienteResponseDTO();
                pacienteResponseDTO.Nome = pacienteModel.NomeCompleto;
                pacienteResponseDTO.CPF = pacienteModel.CPF;
                pacienteResponseDTO.ContatoEmergencia = pacienteModel.ContatoEmergencia;
                pacienteResponseDTO.CuidadosEspecificos = pacienteModel.CuidadosEspecificos;
                pacienteResponseDTO.Alergias = pacienteModel.Alergias;
                pacienteResponseDTO.DataNascimento = pacienteModel.DataNascimento;
                pacienteResponseDTO.Convenio = pacienteModel.Convenio;
                pacienteResponseDTO.Genero = pacienteModel.Genero;
                pacienteResponseDTO.Telefone = pacienteModel.Telefone;
                pacienteResponseDTO.Codigo = pacienteModel.Id;
                pacienteResponseDTO.Atendimentos = pacienteModel.TotalAtendimentos;

                return StatusCode(201, pacienteResponseDTO);

            }

            catch (Exception)
            {
                return StatusCode(400, $"Ocorreu um erro na requisição! Tente novamente mais tarde.");
            }
        }

        [HttpPut("/pacientes2/{identificador}")]
        public ActionResult<PacienteResponseDTO> Put([FromRoute] int identificador, PacienteUpdateDTO pacienteUpdateDTO)
        {
            try
            {
                //Verificar se existe o paciente no banco de dados
                var pacienteModel = _labMedicineBdContext.Pacientes.Where(x => x.Id == identificador).FirstOrDefault();
                //se nao existir, retorna que nao encontrou e termina aqui a rotina
                if (pacienteModel == null)
                    return StatusCode(404, "Paciente não encontrado com o identificador informado.");

                //se existir, verifica se os campos estão preenchidos e alimenta a model com a DTO
                if (pacienteUpdateDTO.Nome != null)
                    pacienteModel.NomeCompleto = pacienteUpdateDTO.Nome;
                if (pacienteUpdateDTO.Genero != null)
                    pacienteModel.Genero = pacienteUpdateDTO.Genero;
                pacienteModel.DataNascimento = pacienteUpdateDTO.DataNascimento;
                if (pacienteUpdateDTO.Telefone != null)
                    pacienteModel.Telefone = pacienteUpdateDTO.Telefone;
                if (pacienteUpdateDTO.ContatoEmergencia != null)
                    pacienteModel.ContatoEmergencia = pacienteUpdateDTO.ContatoEmergencia;
                if (pacienteUpdateDTO.Alergias != null)
                    pacienteModel.Alergias = pacienteUpdateDTO.Alergias;
                if (pacienteUpdateDTO.CuidadosEspecificos != null)
                    pacienteModel.CuidadosEspecificos = pacienteUpdateDTO.CuidadosEspecificos;
                if (pacienteUpdateDTO.Convenio != null)
                    pacienteModel.Convenio = pacienteUpdateDTO.Convenio;

                pacienteModel.StatusAtendimento = pacienteUpdateDTO.StatusAtendimento;

                //Atualiza no banco
                _labMedicineBdContext.Pacientes.Attach(pacienteModel);

                //Salvar no banco de dados
                _labMedicineBdContext.SaveChanges();

                //Cria um objeto DTO para retornar ao usuario os campos atualizados
                PacienteResponseDTO pacienteResponseDTO = new PacienteResponseDTO();
                pacienteResponseDTO.Nome = pacienteModel.NomeCompleto;
                pacienteResponseDTO.CPF = pacienteModel.CPF;
                pacienteResponseDTO.ContatoEmergencia = pacienteModel.ContatoEmergencia;
                pacienteResponseDTO.CuidadosEspecificos = pacienteModel.CuidadosEspecificos;
                pacienteResponseDTO.Alergias = pacienteModel.Alergias;
                pacienteResponseDTO.DataNascimento = pacienteModel.DataNascimento;
                pacienteResponseDTO.Convenio = pacienteModel.Convenio;
                pacienteResponseDTO.Genero = pacienteModel.Genero;
                pacienteResponseDTO.Telefone = pacienteModel.Telefone;
                pacienteResponseDTO.Codigo = pacienteModel.Id;
                pacienteResponseDTO.Atendimentos = pacienteModel.TotalAtendimentos;

                return StatusCode(200, pacienteResponseDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpDelete("/pacientes2/{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                //Verificar se existe no banco de dados
                var pacienteModel = _labMedicineBdContext.Pacientes.Find(identificador);

                //se existir
                if (pacienteModel != null)
                {
                    //apaga
                    _labMedicineBdContext.Pacientes.Remove(pacienteModel);

                    //Salva as alterações no banco
                    _labMedicineBdContext.SaveChanges();

                    //Retorna sem conteudo, dizendo que deu certo
                    return StatusCode(204);
                }
                else
                    //se nao existir, avisa
                    return StatusCode(404, "Paciente não encontrado com o identificador informado.");

            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/pacientes2")]
        public ActionResult<List<PacienteResponseDTO>> Get([FromQuery] PacienteStatusRequestDTO status)
        {
            try
            {
                //Cria um novo objeto de lista para retornar
                List<PacienteResponseDTO> lista = new();

                //Referencia a classe para alimentar com o retorno da consulta
                IQueryable<PacienteModel> pacientesInnerJoin;

                //se o status do atendimento foi informado, entao filtra a consulta pelo status, senao busca todos
                if (status.StatusAtendimento != null)
                    pacientesInnerJoin = _labMedicineBdContext.Pacientes.Where(x => x.StatusAtendimento == status.StatusAtendimento);
                else
                    pacientesInnerJoin = _labMedicineBdContext.Pacientes;

                //Referencia a classe DTO para usar o objeto dentro do for.
                PacienteResponseDTO pacienteResponseDTO;

                //se encontrou algum resultado na consulta então navega neles pra alimentar a lista
                if (pacientesInnerJoin.Any())
                {
                    foreach (PacienteModel paciente in pacientesInnerJoin)
                    {
                        //Cria um novo objeto DTO para adicionar na lista de retorno
                        pacienteResponseDTO = new PacienteResponseDTO();

                        //Alimenta o objeto DTO
                        pacienteResponseDTO.Nome = paciente.NomeCompleto;
                        pacienteResponseDTO.CPF = paciente.CPF;
                        pacienteResponseDTO.ContatoEmergencia = paciente.ContatoEmergencia;
                        pacienteResponseDTO.CuidadosEspecificos = paciente.CuidadosEspecificos;
                        pacienteResponseDTO.Alergias = paciente.Alergias;
                        pacienteResponseDTO.DataNascimento = paciente.DataNascimento;
                        pacienteResponseDTO.Convenio = paciente.Convenio;
                        pacienteResponseDTO.Genero = paciente.Genero;
                        pacienteResponseDTO.Telefone = paciente.Telefone;
                        pacienteResponseDTO.Codigo = paciente.Id;
                        pacienteResponseDTO.Atendimentos = paciente.TotalAtendimentos;

                        //Adiciona na lista de retorno
                        lista.Add(pacienteResponseDTO);
                    }

                    //retorna a lista
                    return lista;
                }
                else
                {
                    //se não encontrou ninguem
                    return StatusCode(404, "Nenhum paciente encontrado.");
                }

            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/pacientes2/{identificador}")]
        public ActionResult<PacienteResponseDTO> GetPorId([FromRoute] int identificador)
        {
            try
            {
                PacienteModel paciente = _labMedicineBdContext.Pacientes.Where(w => w.Id == identificador).FirstOrDefault();
                if (paciente == null)
                    throw new MyException(404, "Paciente não encontrado para o identificador informado.");

                //Alimenta o objeto DTO
                PacienteResponseDTO pacienteResponseDTO = new PacienteResponseDTO();
                pacienteResponseDTO.Nome = paciente.NomeCompleto;
                pacienteResponseDTO.CPF = paciente.CPF;
                pacienteResponseDTO.ContatoEmergencia = paciente.ContatoEmergencia;
                pacienteResponseDTO.CuidadosEspecificos = paciente.CuidadosEspecificos;
                pacienteResponseDTO.Alergias = paciente.Alergias;
                pacienteResponseDTO.DataNascimento = paciente.DataNascimento;
                pacienteResponseDTO.Convenio = paciente.Convenio;
                pacienteResponseDTO.Genero = paciente.Genero;
                pacienteResponseDTO.Telefone = paciente.Telefone;
                pacienteResponseDTO.Codigo = paciente.Id;
                pacienteResponseDTO.Atendimentos = paciente.TotalAtendimentos;

                return StatusCode(200, pacienteResponseDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }

        }
    }
}
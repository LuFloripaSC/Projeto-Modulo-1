using LABMedicine.DTOs;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly LabMedicineBdContext _labMedicineBdContext;

        //Construtor com parametro (Injetado)   
        public MedicoController(LabMedicineBdContext labMedicineBdContext) => _labMedicineBdContext = labMedicineBdContext;

        [HttpPost("/medicos")]
        public ActionResult<MedicoCreateDTO> Post([FromBody] MedicoCreateDTO medicoDTO)
        {

            try //tente fazer tudo que ta abaixo entre as chaves
            {
                //se alguma coisa der errado aqui, entao para tudo e executa o catch..

                MedicoModel medicoModel; //Classe referenciada                
                medicoModel = new MedicoModel(); //Objeto pacienteModel; new = instancia

                medicoModel.NomeCompleto = medicoDTO.NomeCompleto;
                medicoModel.CPF = medicoDTO.CPF;
                medicoModel.CRM = medicoDTO.CRMUF;
                medicoModel.Ensino = medicoDTO.InstituicaoEnsino;
                medicoModel.Especializacao = medicoModel.Especializacao;
                medicoModel.DataNascimento = medicoDTO.DataNascimento;
                medicoModel.EstadoNoSistema = medicoDTO.SituacaoSistema;
                medicoModel.Genero = medicoDTO.Genero;
                medicoModel.Telefone = medicoDTO.Telefone;
                medicoModel.AtendimentosRealizados = medicoDTO.TotalAtendimentos;

                var resultadoDaConsulta = _labMedicineBdContext.Medicos.Where(ttt => ttt.CPF == medicoModel.CPF).FirstOrDefault();
                if (resultadoDaConsulta != null)
                {
                    return StatusCode(409, "CPF informado já existe no cadastro.");
                }

                //se o codigo passar por aqui, insere no banco, pq o CPF nao existe la.
                _labMedicineBdContext.Medicos.Add(medicoModel);

                //Salva essa altearção no banco
                _labMedicineBdContext.SaveChanges();

                //Cria o objeto DTO e alimenta pra retornar ao usuario na tela
                MedicoReturnDTO medicoReturnDTO = new MedicoReturnDTO();
                medicoReturnDTO.NomeCompleto = medicoModel.NomeCompleto;
                medicoReturnDTO.CPF = medicoModel.CPF;
                medicoReturnDTO.CRMUF = medicoModel.CRM;
                medicoReturnDTO.InstituicaoEnsino = medicoModel.Ensino;
                medicoReturnDTO.EspecializacaoClinica = medicoModel.Especializacao;
                medicoReturnDTO.DataNascimento = medicoModel.DataNascimento;
                medicoReturnDTO.Genero = medicoModel.Genero;
                medicoReturnDTO.Telefone = medicoModel.Telefone;
                medicoReturnDTO.intentificador = medicoModel.Id;
                medicoReturnDTO.SituacaoSistema = medicoModel.EstadoNoSistema;
                medicoReturnDTO.TotalAtendimentos = medicoModel.AtendimentosRealizados;
                {
                    return StatusCode(201, medicoReturnDTO);
                }

            }

            catch (Exception)
            {
                return StatusCode(400, $"Ocorreu um erro na requisição! Tente novamente mais tarde.");
            }
        }

        [HttpPut("/medicos/{identificador}")]
        public ActionResult<MedicoReturnDTO> Put([FromRoute] int identificador, MedicoUpdateDTO medicoUpdateDTO)
        {
            try
            {
                //Verificar se existe o paciente no banco de dados
                var medicoModel = _labMedicineBdContext.Medicos.Where(x => x.Id == identificador).FirstOrDefault();
                //se nao existir, retorna que nao encontrou e termina aqui a rotina
                if (medicoModel == null)
                    return StatusCode(404, "Medico não encontrado com o identificador informado.");

                //se existir, verifica se os campos estão preenchidos e alimenta a model com a DTO
                if (medicoUpdateDTO.NomeCompleto != null)
                    medicoModel.NomeCompleto = medicoUpdateDTO.NomeCompleto;
                if (medicoUpdateDTO.Genero != null)
                    medicoModel.Genero = medicoUpdateDTO.Genero;
                medicoModel.DataNascimento = medicoUpdateDTO.DataNascimento;
                if (medicoUpdateDTO.Telefone != null)
                    medicoModel.Telefone = medicoUpdateDTO.Telefone;
                if (medicoUpdateDTO.InstituicaoEnsino != null)
                    medicoModel.Ensino = medicoUpdateDTO.InstituicaoEnsino;
                if (medicoUpdateDTO.CRMUF != null)
                    medicoModel.CRM = medicoUpdateDTO.CRMUF;
                if (medicoUpdateDTO.EspecializacaoClinica != null)
                    medicoModel.Especializacao = medicoUpdateDTO.EspecializacaoClinica;
                if (medicoUpdateDTO.TotalAtendimentos != null)
                    medicoModel.AtendimentosRealizados = medicoUpdateDTO.TotalAtendimentos;

                medicoModel.EstadoNoSistema = medicoUpdateDTO.SituacaoSistema;

                //Atualiza no banco
                _labMedicineBdContext.Medicos.Attach(medicoModel);

                //Salvar no banco de dados
                _labMedicineBdContext.SaveChanges();

                //Cria um objeto DTO para retornar ao usuario os campos atualizados
                MedicoReturnDTO medicoReturnDTO = new MedicoReturnDTO();
                medicoReturnDTO.NomeCompleto = medicoModel.NomeCompleto;
                medicoReturnDTO.CPF = medicoModel.CPF;
                medicoReturnDTO.CRMUF = medicoModel.CRM;
                medicoReturnDTO.EspecializacaoClinica = medicoModel.Especializacao;
                medicoReturnDTO.InstituicaoEnsino= medicoModel.Ensino;
                medicoReturnDTO.DataNascimento = medicoModel.DataNascimento;
                medicoReturnDTO.Genero = medicoModel.Genero;
                medicoReturnDTO.Telefone = medicoModel.Telefone;
                medicoReturnDTO.intentificador = medicoModel.Id;
                medicoReturnDTO.TotalAtendimentos = medicoModel.AtendimentosRealizados;

                return StatusCode(200, medicoReturnDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpDelete("/medicos/{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                //Verificar se existe no banco de dados
                var medicoModel = _labMedicineBdContext.Medicos.Find(identificador);

                //se existir
                if (medicoModel != null)
                {
                    //apaga
                    _labMedicineBdContext.Medicos.Remove(medicoModel);

                    //Salva as alterações no banco
                    _labMedicineBdContext.SaveChanges();

                    //Retorna sem conteudo, dizendo que deu certo
                    return StatusCode(204);
                }
                else
                    //se nao existir, avisa
                    return StatusCode(404, "Medico não encontrado com o identificador informado.");

            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/medicos")]
        public ActionResult<List<MedicoReturnDTO>> Get(EnumEstadoNoSistema? status)
        {
            try
            {
                //Cria um novo objeto de lista para retornar
                List<MedicoReturnDTO> lista = new();

                //Referencia a classe para alimentar com o retorno da consulta
                IQueryable<MedicoModel> medicosInnerJoin;

                //se o status do atendimento foi informado, entao filtra a consulta pelo status, senao busca todos
                if (status != null)
                    medicosInnerJoin = _labMedicineBdContext.Medicos.Where(x => x.EstadoNoSistema == status);
                else
                    medicosInnerJoin = _labMedicineBdContext.Medicos;

                //Referencia a classe DTO para usar o objeto dentro do for.
                MedicoReturnDTO medicoReturnDTO;

                //se encontrou algum resultado na consulta então navega neles pra alimentar a lista
                if (medicosInnerJoin.Any())
                {
                    foreach (MedicoModel medico in medicosInnerJoin)
                    {
                        //Cria um novo objeto DTO para adicionar na lista de retorno
                        medicoReturnDTO = new MedicoReturnDTO();

                        //Alimenta o objeto DTO
                        medicoReturnDTO.NomeCompleto = medico.NomeCompleto;
                        medicoReturnDTO.CPF = medico.CPF;
                        medicoReturnDTO.CRMUF = medico.CRM;
                        medicoReturnDTO.EspecializacaoClinica = medico.Especializacao;
                        medicoReturnDTO.InstituicaoEnsino = medico.Ensino;
                        medicoReturnDTO.DataNascimento = medico.DataNascimento;
                        medicoReturnDTO.Genero = medico.Genero;
                        medicoReturnDTO.Telefone = medico.Telefone;
                        medicoReturnDTO.intentificador = medico.Id;
                        medicoReturnDTO.TotalAtendimentos = medico.AtendimentosRealizados;
                        medicoReturnDTO.SituacaoSistema = medico.EstadoNoSistema;

                        //Adiciona na lista de retorno
                        lista.Add(medicoReturnDTO);
                    }

                    //retorna a lista
                    return lista;
                }
                else
                {
                    //se não encontrou ninguem
                    return StatusCode(404, "Nenhum medico encontrado.");
                }

            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/medicos/{identificador}")]
        public ActionResult<MedicoReturnDTO> GetPorId([FromRoute] int identificador)
        {
            try
            {
                MedicoModel medico = _labMedicineBdContext.Medicos.Where(w => w.Id == identificador).FirstOrDefault();
                if (medico == null)
                    return StatusCode (404, "Medico não encontrado para o identificador informado.");

                //Alimenta o objeto DTO
                MedicoReturnDTO medicoReturnDTO = new MedicoReturnDTO();
                medicoReturnDTO.NomeCompleto = medico.NomeCompleto;
                medicoReturnDTO.CPF = medico.CPF;
                medicoReturnDTO.CRMUF = medico.CRM;
                medicoReturnDTO.InstituicaoEnsino = medico.Ensino;
                medicoReturnDTO.EspecializacaoClinica = medico.Especializacao;
                medicoReturnDTO.DataNascimento = medico.DataNascimento;
                medicoReturnDTO.Genero = medico.Genero;
                medicoReturnDTO.Telefone = medico.Telefone;
                medicoReturnDTO.intentificador = medico.Id;
                medicoReturnDTO.TotalAtendimentos = medico.AtendimentosRealizados;
                medicoReturnDTO.SituacaoSistema = medico.EstadoNoSistema;

                return StatusCode(200, medicoReturnDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }

        }
    }
}

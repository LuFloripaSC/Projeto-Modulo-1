using LABMedicine.DTOs;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeiroController : ControllerBase
    {
        private readonly LabMedicineBdContext _labMedicineBdContext;

        //Construtor com parametro (Injetado)   
        public EnfermeiroController(LabMedicineBdContext labMedicineBdContext) => _labMedicineBdContext = labMedicineBdContext;

        [HttpPost("/enfermeiros")]
        public ActionResult<EnfermeiroCreateDTO> Post([FromBody] EnfermeiroCreateDTO enfermeiroDTO)
        {

            try //tente fazer tudo que ta abaixo entre as chaves
            {
                //se alguma coisa der errado aqui, entao para tudo e executa o catch..

                EnfermeiroModel enfermeiroModel; //Classe referenciada                
                enfermeiroModel = new EnfermeiroModel(); //Objeto pacienteModel; new = instancia

                enfermeiroModel.NomeCompleto = enfermeiroDTO.NomeCompleto;
                enfermeiroModel.CPF = enfermeiroDTO.CPF;
                enfermeiroModel.Cofen = enfermeiroDTO.Cofen;
                enfermeiroModel.EnsinoEnfermeiro = enfermeiroDTO.EnsinoEnfermeiro;
                enfermeiroModel.DataNascimento = enfermeiroDTO.DataNascimento;
                enfermeiroModel.Genero = enfermeiroDTO.Genero;
                enfermeiroModel.Telefone = enfermeiroDTO.Telefone;

                var resultadoDaConsulta = _labMedicineBdContext.Enfermeiros.Where(ttt => ttt.CPF == enfermeiroModel.CPF).FirstOrDefault();
                if (resultadoDaConsulta != null)
                {
                    return StatusCode(409, "CPF informado já existe no cadastro.");
                }

                //se o codigo passar por aqui, insere no banco, pq o CPF nao existe la.
                _labMedicineBdContext.Enfermeiros.Add(enfermeiroModel);

                //Salva essa altearção no banco
                _labMedicineBdContext.SaveChanges();

                //Cria o objeto DTO e alimenta pra retornar ao usuario na tela
                EnfermeiroReturnDTO enfermeiroReturnDTO = new EnfermeiroReturnDTO();
                enfermeiroReturnDTO.NomeCompleto = enfermeiroModel.NomeCompleto;
                enfermeiroDTO.CPF = enfermeiroModel.CPF;
                enfermeiroReturnDTO.Cofen = enfermeiroModel.Cofen;
                enfermeiroReturnDTO.EnsinoEnfermeiro = enfermeiroModel.EnsinoEnfermeiro;
                enfermeiroReturnDTO.DataNascimento = enfermeiroModel.DataNascimento;
                enfermeiroReturnDTO.Genero = enfermeiroModel.Genero;
                enfermeiroReturnDTO.Telefone = enfermeiroModel.Telefone;
                enfermeiroReturnDTO.intentificador = enfermeiroModel.Id;
                
                    return StatusCode(201, enfermeiroReturnDTO);
                

            }

            catch (Exception)
            {
                return StatusCode(400, $"Ocorreu um erro na requisição! Tente novamente mais tarde.");
            }
        }

        [HttpPut("/enfermeiros/{identificador}")]
        public ActionResult<EnfermeiroReturnDTO> Put([FromRoute] int identificador, EnfermeiroUpdateDTO enfermeiroUpdateDTO)
        {
            try
            {
                //Verificar se existe o paciente no banco de dados
                var enfermeiroModel = _labMedicineBdContext.Enfermeiros.Where(x => x.Id == identificador).FirstOrDefault();
                //se nao existir, retorna que nao encontrou e termina aqui a rotina
                if (enfermeiroModel == null)
                    return StatusCode(404, "Enfermeiro não encontrado com o identificador informado.");

                //se existir, verifica se os campos estão preenchidos e alimenta a model com a DTO
                if (enfermeiroUpdateDTO.NomeCompleto != null)
                    enfermeiroModel.NomeCompleto = enfermeiroUpdateDTO.NomeCompleto;
                if (enfermeiroUpdateDTO.Genero != null)
                    enfermeiroModel.Genero = enfermeiroUpdateDTO.Genero;
                enfermeiroModel.DataNascimento = enfermeiroUpdateDTO.DataNascimento;
                if (enfermeiroUpdateDTO.Telefone != null)
                    enfermeiroModel.Telefone = enfermeiroUpdateDTO.Telefone;
                if (enfermeiroUpdateDTO.EnsinoEnfermeiro != null)
                    enfermeiroModel.EnsinoEnfermeiro = enfermeiroUpdateDTO.EnsinoEnfermeiro;
                if (enfermeiroUpdateDTO.Cofen != null)
                    enfermeiroModel.Cofen = enfermeiroUpdateDTO.Cofen;

                //Atualiza no banco
                _labMedicineBdContext.Enfermeiros.Attach(enfermeiroModel);

                //Salvar no banco de dados
                _labMedicineBdContext.SaveChanges();

                //Cria um objeto DTO para retornar ao usuario os campos atualizados
                EnfermeiroReturnDTO enfermeiroReturnDTO = new EnfermeiroReturnDTO();
                enfermeiroReturnDTO.NomeCompleto = enfermeiroModel.NomeCompleto;
                enfermeiroReturnDTO.CPF = enfermeiroModel.CPF;
                enfermeiroReturnDTO.Cofen = enfermeiroModel.Cofen;
                enfermeiroReturnDTO.EnsinoEnfermeiro = enfermeiroModel.EnsinoEnfermeiro;
                enfermeiroReturnDTO.DataNascimento = enfermeiroModel.DataNascimento;
                enfermeiroReturnDTO.Genero = enfermeiroModel.Genero;
                enfermeiroReturnDTO.Telefone = enfermeiroModel.Telefone;
                enfermeiroReturnDTO.intentificador = enfermeiroModel.Id;

                return StatusCode(200, enfermeiroReturnDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpDelete("/enfermeiros/{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                //Verificar se existe no banco de dados
                var enfermeiroModel = _labMedicineBdContext.Enfermeiros.Find(identificador);

                //se existir
                if (enfermeiroModel != null)
                {
                    //apaga
                    _labMedicineBdContext.Enfermeiros.Remove(enfermeiroModel);

                    //Salva as alterações no banco
                    _labMedicineBdContext.SaveChanges();

                    //Retorna sem conteudo, dizendo que deu certo
                    return StatusCode(204);
                }
                else
                    //se nao existir, avisa
                    return StatusCode(404, "Enfermeiro não encontrado com o identificador informado.");
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/enfermeiros")]
        public ActionResult<List<EnfermeiroReturnDTO>> Get()
        {
            try
            {
                //Cria um novo objeto de lista para retornar
                List<EnfermeiroReturnDTO> lista = new();

                //Referencia a classe para alimentar com o retorno da consulta
                IQueryable<EnfermeiroModel> enfermeirosInnerJoin;

                enfermeirosInnerJoin = _labMedicineBdContext.Enfermeiros;

                //Referencia a classe DTO para usar o objeto dentro do for.
                EnfermeiroReturnDTO enfermeiroReturnDTO;

                //se encontrou algum resultado na consulta então navega neles pra alimentar a lista
                if (enfermeirosInnerJoin.Any())
                {
                    foreach (EnfermeiroModel enfermeiro in enfermeirosInnerJoin)
                    {
                        //Cria um novo objeto DTO para adicionar na lista de retorno
                        enfermeiroReturnDTO = new EnfermeiroReturnDTO();

                        //Alimenta o objeto DTO
                        enfermeiroReturnDTO.NomeCompleto = enfermeiro.NomeCompleto;
                        enfermeiroReturnDTO.CPF = enfermeiro.CPF;
                        enfermeiroReturnDTO.Cofen = enfermeiro.Cofen;
                        enfermeiroReturnDTO.EnsinoEnfermeiro = enfermeiro.EnsinoEnfermeiro;
                        enfermeiroReturnDTO.DataNascimento = enfermeiro.DataNascimento;
                        enfermeiroReturnDTO.Genero = enfermeiro.Genero;
                        enfermeiroReturnDTO.Telefone = enfermeiro.Telefone;
                        enfermeiroReturnDTO.intentificador = enfermeiro.Id;

                        //Adiciona na lista de retorno
                        lista.Add(enfermeiroReturnDTO);
                    }

                    //retorna a lista
                    return lista;
                }
                else
                {
                    //se não encontrou ninguem
                    return StatusCode(404, "Nenhum enfermeiro encontrado.");
                }

            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }

        [HttpGet("/enfermeiros/{identificador}")]
        public ActionResult<EnfermeiroReturnDTO> GetPorId([FromRoute] int identificador)
        {
            try
            {
                EnfermeiroModel enfermeiro = _labMedicineBdContext.Enfermeiros.Where(w => w.Id == identificador).FirstOrDefault();
                if (enfermeiro == null)
                    return StatusCode(404, "Enfermeiro não encontrado para o identificador informado.");

                //Alimenta o objeto DTO
                EnfermeiroReturnDTO enfermeiroReturnDTO = new EnfermeiroReturnDTO();
                enfermeiroReturnDTO.NomeCompleto = enfermeiro.NomeCompleto;
                enfermeiroReturnDTO.CPF = enfermeiro.CPF;
                enfermeiroReturnDTO.Cofen = enfermeiro.Cofen;
                enfermeiroReturnDTO.EnsinoEnfermeiro = enfermeiro.EnsinoEnfermeiro;
                enfermeiroReturnDTO.DataNascimento = enfermeiro.DataNascimento;
                enfermeiroReturnDTO.Genero = enfermeiro.Genero;
                enfermeiroReturnDTO.Telefone = enfermeiro.Telefone;
                enfermeiroReturnDTO.intentificador = enfermeiro.Id;

                return StatusCode(200, enfermeiroReturnDTO);
            }

            catch (Exception)
            {
                return StatusCode(400, "Dados inválidos!");
            }
        }
    }
}

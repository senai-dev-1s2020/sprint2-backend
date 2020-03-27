using System;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes às instituições
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _instituicaoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IInstituicaoRepository _instituicaoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public InstituicoesController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns>Uma lista de instituições e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de instituições</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Instituições
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_instituicaoRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma instituição através do ID
        /// </summary>
        /// <param name="id">ID da instituição que será buscada</param>
        /// <returns>Uma instituição buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a instituição buscada</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Instituicoes/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto instituicaoBuscada
                Instituicao instituicaoBuscada= _instituicaoRepository.BuscarPorId(id);

                // Verifica se a instituição foi encontrada
                if (instituicaoBuscada != null)
                {
                    // Retora a resposta da requisição 200 - OK e a instituição que foi encontrada
                    return Ok(instituicaoBuscada);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma instituição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Instituicoes
        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            try
            {
                // Faz a chamada para o método
                _instituicaoRepository.Cadastrar(novaInstituicao);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma instituição existente
        /// </summary>
        /// <param name="id">ID da instituição que será atualizada</param>
        /// <param name="instituiçãoAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Instituicoes/id
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Instituicao instituiçãoAtualizada)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto instituicaoBuscada
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                // Verifica se a instituição foi encontrada
                if (instituicaoBuscada != null)
                {
                    // Faz a chamada para o método
                    _instituicaoRepository.Atualizar(id, instituiçãoAtualizada);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma instituição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">ID da instituição que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Instituicoes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto instituicaoBuscada
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                // Verifica se a instituição foi encontrada
                if (instituicaoBuscada != null)
                {
                    // Faz a chamada para o método
                    _instituicaoRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma instituição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
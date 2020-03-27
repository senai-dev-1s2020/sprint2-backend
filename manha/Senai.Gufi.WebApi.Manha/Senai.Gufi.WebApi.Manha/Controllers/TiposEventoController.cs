using System;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos tipos de evento
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _tipoEventoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITipoEventoRepository _tipoEventoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Uma lista de tipos de evento e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipos de evento</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposEvento
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o tipo de evento buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposEvento/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoEventoBuscado
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                // Verifica se o tipo de evento foi encontrado
                if (tipoEventoBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o tipo de evento que foi encontrado
                    return Ok(tipoEventoBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposEvento
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                // Faz a chamada para o método
                _tipoEventoRepository.Cadastrar(novoTipoEvento);

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
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposEvento/id
        [HttpPatch("{id}")]
        public IActionResult Put(int id, TipoEvento tipoEventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoEventoBuscado
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                // Verifica se o tipo de evento foi encontrado
                if (tipoEventoBuscado != null)
                {
                    // Faz a chamada para o método
                    _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposEvento/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoEventoBuscado
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                // Verifica se o tipo de evento foi encontrado
                if (tipoEventoBuscado != null)
                {
                    // Faz a chamada para o método
                    _tipoEventoRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
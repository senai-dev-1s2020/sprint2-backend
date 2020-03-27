using System;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos eventos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class EventosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _eventoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEventoRepository _eventoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EventosController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de eventos</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um evento através do ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o evento buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto eventoBuscado
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                // Verifica se o evento foi encontrado
                if (eventoBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o evento que foi encontrado
                    return Ok(eventoBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                // Faz a chamada para o método
                _eventoRepository.Cadastrar(novoEvento);

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
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos/id
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto eventoBuscado
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                // Verifica se o evento foi encontrado
                if (eventoBuscado != null)
                {
                    // Faz a chamada para o método
                    _eventoRepository.Atualizar(id, eventoAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Eventos/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto eventoBuscado
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                // Verifica se o evento foi encontrado
                if (eventoBuscado != null)
                {
                    // Faz a chamada para o método
                    _eventoRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum evento encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
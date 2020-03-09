using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos jogos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _jogoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IJogoRepository _jogoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.Listar());
        }

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um estúdio buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            // Faz a chamada para o método
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            // Faz a chamada para o método
            _jogoRepository.Atualizar(id, jogoAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _jogoRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os jogos com as informações dos estúdios
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        [HttpGet("Estudios")]
        public IActionResult GetEstudios()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.ListarComEstudios());
        }

        /// <summary>
        /// Lista todos os jogos de um determinado estúdio
        /// </summary>
        /// <param name="id">ID do estúdio do qual os jogos serão listados</param>
        /// <returns>Uma lista de jogos</returns>
        [HttpGet("Estudios/{id}")]
        public IActionResult GetUmEstudio(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.ListarUmEstudio(id));
        }
    }
}
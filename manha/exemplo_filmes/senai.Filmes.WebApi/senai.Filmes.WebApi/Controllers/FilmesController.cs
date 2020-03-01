using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos filmes
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _filmeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes e um status code 200 - Ok</returns>
        /// dominio/api/Filmes
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_filmeRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme que será cadastrado</param>
        /// <returns>Retorna os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Filmes
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            // Faz a chamada para o método .Cadastrar();
            _filmeRepository.Cadastrar(novoFilme);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Filmes", novoFilme);
        }

        /// <summary>
        /// Busca um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Retorna um filme buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Filmes/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se algum filme foi encontrado
            if (filmeBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(filmeBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum filme encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Filmes/1
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filmeAtualizado)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se algum filme foi encontrado
            if (filmeBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _filmeRepository.Atualizar(id, filmeAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Filmes/1
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se o filme foi encontrado
            if (filmeBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _filmeRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O filme {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum filme encontrado para o identificador informado");
        }

        /// <summary>
        /// Lista todos os filmes através de uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de filmes encontrados</returns>
        /// dominio/api/Filmes/pesquisar/palavra-chave
        [HttpGet("pesquisar/{busca}")]
        public IActionResult GetByTitle(string busca)
        {
            // Faz a chamada para o método .BuscarPorTitulo()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_filmeRepository.BuscarPorTitulo(busca));
        }
    }
}
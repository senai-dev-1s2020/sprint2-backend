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
    /// Controller responsável pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _generoRepository.Listar();
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto genero recebido na requisição</param>
        /// <returns>Retorna um status code 201 (created)</returns>
        /// dominio/api/Generos
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar();
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um gênero através do seu ID
        /// </summary>
        /// <param name="id">ID do gênero buscado</param>
        /// <returns>Retorna um gênero buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }

            // Caso seja encontrado, retorna o gênero buscado
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Atualiza um gênero existente passando o ID no corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto gênero que será atualizado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        /// dominio/api/Generos
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpPut]
        public IActionResult PutIdCorpo(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.IdGenero);

            // Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

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
                        mensagem = "Gênero não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Atualiza um gênero existente passando o ID no recurso
        /// </summary>
        /// <param name="id">ID do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto gênero que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Generos/1
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Gênero não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

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

        /// <summary>
        /// Deleta um gênero passando o ID
        /// </summary>
        /// <param name="id">ID do gênero que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem personalizada</returns>
        /// dominio/api/Generos/1
        [Authorize(Roles = "Administrador")]    // Define que apenas o Administrador pode acessar o endpoint
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _generoRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Gênero deletado");
        }
    }
}
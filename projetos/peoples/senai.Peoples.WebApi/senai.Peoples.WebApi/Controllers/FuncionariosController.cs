using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using senai.Peoples.WebApi.Repositories;

namespace senai.Peoples.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos funcionarios
    /// </summary>
    
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que somente usuários logados possam acessar os endpoints
    [Authorize]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _funcionarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///     {
        ///         "idFuncionario": 0,
        ///         "nome": "Name",
        ///         "sobrenome": "LastName",
        ///         "dataNascimento": "YYYY-MM-DDTHH:MM:SS"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Uma lista de funcionarios e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de funcionários</response>
        /// dominio/api/Funcionarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_funcionarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario que será cadastrado</param>
        /// <returns>Retorna os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            if (novoFuncionario.Nome == null)
            {
                return BadRequest("O nome do funcionário é obrigatório!");
            }
            // Faz a chamada para o método .Cadastrar();
            _funcionarioRepository.Cadastrar(novoFuncionario);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Funcionarios", novoFuncionario);
        }

        /// <summary>
        /// Busca um funcionário através do seu ID
        /// </summary>
        /// <param name="id">ID do funcionário que será buscado</param>
        /// <returns>Retorna um funcionário buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Funcionarios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Verifica se algum funcionário foi encontrado
            if (funcionarioBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(funcionarioBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum funcionário encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um funcionário existente
        /// </summary>
        /// <param name="id">ID do funcionário que será atualizado</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Funcionarios/1
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Verifica se algum funcionário foi encontrado
            if (funcionarioBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _funcionarioRepository.Atualizar(id, funcionarioAtualizado);

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
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um funcionário
        /// </summary>
        /// <param name="id">ID do funcionário que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Funcionarios/1
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Verifica se o funcionário foi encontrado
            if (funcionarioBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _funcionarioRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O funcionário {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum funcionário encontrado para o identificador informado");
        }

        /// <summary>
        /// Lista todos os funcionários através de uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de funcionários encontrados</returns>
        /// dominio/api/Funcionarios/pesquisar/palavra-chave
        [HttpGet("buscar/{busca}")]
        public IActionResult GetByName(string busca)
        {
            // Faz a chamada para o método .BuscarPorNome()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_funcionarioRepository.BuscarPorNome(busca));
        }

        /// <summary>
        /// Lista todos os funcionários com os nomes completos
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        /// dominio/api/Funcionarios/nomescompletos
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpGet("nomescompletos")]
        public IActionResult GetFullName()
        {
            // Faz a chamada para o método .ListarNomeCompleto            
            // Retorna a lista e um status code 200 - Ok
            return Ok(_funcionarioRepository.ListarNomeCompleto());
        }

        /// <summary>
        /// Lista todos os funcionários de maneira ordenada pelo nome
        /// </summary>
        /// <param name="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de funcionários</returns>
        /// dominio/api/Funcionarios/ordenacao/asc
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetOrderBy(string ordem)
        {
            // Verifica se a ordenação atende aos requisitos
            if (ordem != "ASC" && ordem != "DESC")
            {
                // Caso não, retorna um status code 404 - BadRequest com uma mensagem de erro
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ASC' ou 'DESC'");
            }

            // Retorna a lista ordenada com um status code 200 - OK
            return Ok(_funcionarioRepository.ListarOrdenado(ordem));
        }
    }
}
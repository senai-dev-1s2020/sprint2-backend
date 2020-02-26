using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FuncionarioRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        List<FuncionarioDomain> Listar();

        /// <summary>
        /// Busca um funcionário através do ID
        /// </summary>
        /// <param name="id">ID do funcionário que será buscado</param>
        /// <returns>Retorna um funcionário buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario que será cadastrado</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// Atualiza um funcionário existente
        /// </summary>
        /// <param name="id">ID do funcionário que será atualizado</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado que será atualizado</param>
        void Atualizar(int id, FuncionarioDomain funcionarioAtualizado);

        /// <summary>
        /// Deleta um funcionário existente
        /// </summary>
        /// <param name="id">ID do funcionário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca todos os funcionários que contenham uma palavra-chave
        /// </summary>
        /// <param name="nome">Palavra-chave que servirá de busca</param>
        /// <returns>Retorna uma lista de funcionários encontrados</returns>
        List<FuncionarioDomain> BuscarPorNome(string nome);

        /// <summary>
        /// Lista todos os funcionários com os nomes completos
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        List<FuncionarioDomain> ListarNomeCompleto();

        /// <summary>
        /// Lista todos os funcionários de maneira ordenada pelo nome
        /// </summary>
        /// <param name="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de funcionários</returns>
        List<FuncionarioDomain> ListarOrdenado(string ordem);
    }
}

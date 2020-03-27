using Senai.Gufi.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo InstituicaoRepository
    /// </summary>
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        List<Instituicao> Listar();

        /// <summary>
        /// Busca uma instituição por ID
        /// </summary>
        /// <param name="id">ID da instituição que será buscada</param>
        /// <returns>Uma instituição buscada</returns>
        Instituicao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto com as informações de cadastro</param>
        void Cadastrar(Instituicao novaInstituicao);

        /// <summary>
        /// Atualiza uma instituição existente
        /// </summary>
        /// <param name="id">ID da instituição que será atualizada</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Instituicao instituicaoAtualizada);

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">ID da instituição que será deletada</param>
        void Deletar(int id);
    }
}

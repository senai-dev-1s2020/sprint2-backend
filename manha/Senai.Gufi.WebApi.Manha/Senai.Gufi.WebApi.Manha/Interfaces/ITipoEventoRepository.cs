using Senai.Gufi.WebApi.Manha.Domains;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoEventoRepository
    /// </summary>
    interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Uma lista de tipos de evento</returns>
        List<TipoEvento> Listar();

        /// <summary>
        /// Busca um tipo de evento por ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado</returns>
        TipoEvento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações de cadastro</param>
        void Cadastrar(TipoEvento novoTipoEvento);

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        void Deletar(int id);
    }
}

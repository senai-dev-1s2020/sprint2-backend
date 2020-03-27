using Senai.Gufi.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PresencaRepository
    /// </summary>
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Uma lista de presenças</returns>
        List<Presenca> Listar();

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        void AprovarRecusar(int id, string status);

        /// <summary>
        /// Convida outro usuário para um evento
        /// </summary>
        /// <param name="convite">Objeto com as informações do convite</param>
        void Convidar(Presenca convite);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);
    }
}

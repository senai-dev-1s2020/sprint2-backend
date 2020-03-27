using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelas presenças
    /// </summary>
    public class PresencaRepository : IPresencaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        public void AprovarRecusar(int id, string status)
        {
            // Busca a primeira presença para o ID informado e armazena no objeto presencaBuscada
            Presenca presencaBuscada = ctx.Presenca
                // Adiciona na busca as informações do usuário que participa do evento
                .Include(p => p.IdUsuarioNavigation)
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            // Verifica qual o status foi informado
            switch (status)
            {
                // Se for 1, a situação da presença será "Confirmada"
                case "1": presencaBuscada.Situacao = "Confirmada";
                    break;

                // Se for 0, a situação da presença será "Recusada"
                case "0": presencaBuscada.Situacao = "Recusada";
                    break;

                // Se for 2, a situação da presença será "Não confirmada"
                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                // Se for qualquer valor diferente de 0, 1 e 2, a situação da presença não será alterada
                default: presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            // Atualiza os dados da presença que foi buscado
            ctx.Presenca.Update(presencaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Convida outro usuário para um evento
        /// </summary>
        /// <param name="convite">Objeto com as informações do convite</param>
        public void Convidar(Presenca convite)
        {
            // Independente do status que o usuário tente cadastrar ao convidar outro usuário
            // por padrão, a situação será sempre "Não confirmada"
            convite.Situacao = "Não confirmada";

            // Adiciona uma nova presença
            ctx.Presenca.Add(convite);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        public void Inscrever(Presenca inscricao)
        {
            // Independente do status que o usuário tente cadastrar ao se inscrever
            // por padrão, a situação será sempre "Não confirmada"
            inscricao.Situacao = "Não confirmada";

            // Adiciona uma nova presença
            ctx.Presenca.Add(inscricao);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Uma lista de presenças</returns>
        public List<Presenca> Listar()
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Presenca
                // Adiciona na busca as informações do usuário que participa do evento
                .Include(p => p.IdUsuarioNavigation)
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                .ToList();
        }

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        public List<Presenca> ListarMinhas(int id)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Presenca
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}

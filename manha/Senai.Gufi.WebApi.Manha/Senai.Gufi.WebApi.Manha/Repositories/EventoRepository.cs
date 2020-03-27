using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelos eventos
    /// </summary>
    public class EventoRepository : IEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Evento eventoAtualizado)
        {
            // Busca um evento através do id
            Evento eventoBuscado = ctx.Evento.Find(id);

            // Verifica se o evento foi encontrado
            if (eventoBuscado != null)
            {
                // Verifica se foi informado um novo nome para o evento
                if (eventoAtualizado.NomeEvento != null)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
                }

                // Verifica se foi informada uma nova data para o evento
                if (eventoAtualizado.DataEvento != null)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
                }

                // Verifica se foi informada uma nova descrição para o evento
                if (eventoAtualizado.Descricao != null)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.Descricao = eventoAtualizado.Descricao;
                }

                // Verifica se o acesso livre foi informado
                if (eventoAtualizado.AcessoLivre != null)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.AcessoLivre = eventoAtualizado.AcessoLivre;
                }

                // Verifica se a instituição foi informada
                if (eventoAtualizado.IdInstituicao > 0)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
                }

                // Verifica se a categoria do evento foi informada
                if (eventoAtualizado.IdTipoEvento > 0)
                {
                    // Atribui o novo valor ao campo
                    eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
                }

                // Atualiza os dados do evento que foi buscado
                ctx.Evento.Update(eventoBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um evento por ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado</returns>
        public Evento BuscarPorId(int id)
        {
            // Busca o primeiro evento encontrado para o ID informado e armazena no objeto eventoBuscado
            Evento eventoBuscado = ctx.Evento
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(e => e.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(e => e.IdInstituicaoNavigation)
                .FirstOrDefault(e => e.IdEvento == id);

            // Outra forma
            // Evento eventoBuscado = ctx.Evento.Find(id);

            // Verifica se o evento foi encontrado
            if (eventoBuscado != null)
            {
                // Retorna o evento encontrado
                return eventoBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto com as informações de cadastro</param>
        public void Cadastrar(Evento novoEvento)
        {
            // Adiciona um novo evento
            ctx.Evento.Add(novoEvento);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o evento que foi buscado através do id informado
            ctx.Evento.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um evento através do id
            // Evento eventoBuscado = ctx.Evento.Find(id);

            // Remove o evento que foi buscado
            // ctx.Evento.Remove(eventoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        public List<Evento> Listar()
        {
            // Retorna uma lista com todas as informações dos eventos
            return ctx.Evento
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(e => e.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(e => e.IdInstituicaoNavigation)

                // Outra forma de expressar o Include
                //.Include("IdTipoEventoNavigation")
                //.Include("IdInstituicaoNavigation")

                .ToList();
        }
    }
}

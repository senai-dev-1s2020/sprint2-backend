using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelos tipos de evento
    /// </summary>
    public class TipoEventoRepository : ITipoEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            // Busca um tipo de evento através do id
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            // Verifica se o tipo de evento foi encontrado
            if (tipoEventoBuscado != null)
            {
                // Verifica se foi informado um título do tipo de evento
                if (tipoEventoAtualizado.TituloTipoEvento != null)
                {
                    // Atribui o novo valor ao campo
                    tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
                }

                // Atualiza o título do tipo de evento que foi buscado
                ctx.TipoEvento.Update(tipoEventoBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um tipo de evento por ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado</returns>
        public TipoEvento BuscarPorId(int id)
        {
            // Busca o primeiro tipo de evento encontrado para o ID informado e armazena no objeto tipoEventoBuscado
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.FirstOrDefault(te => te.IdTipoEvento == id);

            // Outra forma
            // TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            // Verifica se o tipo de evento foi encontrado
            if (tipoEventoBuscado != null)
            {
                // Retorna o tipo de evento encontrado
                return tipoEventoBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações de cadastro</param>
        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            // Adiciona um novo tipo de evento
            ctx.TipoEvento.Add(novoTipoEvento);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de evento que foi buscado através do id informado
            ctx.TipoEvento.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um tipo de evento através do id
            // TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            // Remove o tipo de evento que foi buscado
            // ctx.TipoEvento.Remove(tipoEventoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Uma lista de tipos de evento</returns>
        public List<TipoEvento> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de evento
            return ctx.TipoEvento.ToList();
        }
    }
}

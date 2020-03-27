using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelos tipos de usuário
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um tipo de usuário através do id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Verifica se o tipo de usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Verifica se foi informado um título do tipo de usuário
                if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
                {
                    // Atribui o novo valor ao campo
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
                }

                // Atualiza o título do tipo de usuário que foi buscado
                ctx.TipoUsuario.Update(tipoUsuarioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um tipo de usuário por ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            // Busca o primeiro tipo de usuário encontrado para o ID informado e armazena no objeto tipoUsuarioBuscado
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);

            // Outra forma
            // TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Verifica se o tipo de usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Retorna o tipo de usuário encontrado
                return tipoUsuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com as informações de cadastro</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona um novo tipo de usuário
            ctx.TipoUsuario.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado através do id informado
            ctx.TipoUsuario.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um tipo de usuário através do id
            // TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Remove o tipo de usuário que foi buscado
            // ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        public List<TipoUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuário
            return ctx.TipoUsuario.ToList();
        }
    }
}

using Senai.InLock.WebApi.CodeFirst.Contexts;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    /// <summary>
    /// Repositório responsável pelo repositório dos tipos de usuário
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            // Busca um tipo de usuário através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuario.Find(id);

            // Atribui o novo valor ao campo
            tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

            // Atualiza o tipo de usuário que foi buscado
            ctx.TiposUsuario.Update(tipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de usuário para o ID informado
            return ctx.TiposUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com as informações</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            // Adiciona um novo tipo de usuário
            ctx.TiposUsuario.Add(novoTipoUsuario);

            // Salva as informações para serem gravas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de usuário através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuario.Find(id);

            // Remove o tipo de usuário que foi buscado
            ctx.TiposUsuario.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        public List<TiposUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuário
            return ctx.TiposUsuario.ToList();
        }
    }
}

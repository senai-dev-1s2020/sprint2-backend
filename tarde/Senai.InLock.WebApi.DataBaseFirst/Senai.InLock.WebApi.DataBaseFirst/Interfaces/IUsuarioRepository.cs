using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário buscado</param>
        /// <returns>Um usuário buscado</returns>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(Usuarios novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Usuarios usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);
    }
}

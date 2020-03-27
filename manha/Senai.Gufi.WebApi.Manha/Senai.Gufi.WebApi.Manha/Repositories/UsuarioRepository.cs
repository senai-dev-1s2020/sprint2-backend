using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelos usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Verifica se foi informado um nome de usuário
                if (usuarioAtualizado.NomeUsuario != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
                }

                // Verifica se foi informado um e-mail de usuário
                if (usuarioAtualizado.Email != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                // Verifica se foi informada uma senha de usuário
                if (usuarioAtualizado.Senha != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }

                // Verifica se foi informado o gênero do usuário
                if (usuarioAtualizado.Genero != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Genero = usuarioAtualizado.Genero;
                }

                // Verifica se foi informado o tipo do usuário
                if (usuarioAtualizado.IdTipousuario != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.IdTipousuario = usuarioAtualizado.IdTipousuario;
                }

                // Atualiza os dados do usuário que foi buscado
                ctx.Usuario.Update(usuarioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        public Usuario BuscarPorId(int id)
        {
            // Busca o primeiro usuário encontrado para o ID informado e armazena no objeto usuarioBuscado
            // Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            // Outra forma
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Outra forma, não mostrando a senha
            Usuario usuarioBuscado = ctx.Usuario
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new Usuario()
               {
                   IdUsuario = u.IdUsuario,
                   NomeUsuario = u.NomeUsuario,
                   Email = u.Email,
                   Genero = u.Genero,
                   DataCadastro = u.DataCadastro,

                   IdTipousuarioNavigation = new TipoUsuario()
                   {
                       IdTipoUsuario = u.IdTipousuarioNavigation.IdTipoUsuario,
                       TituloTipoUsuario = u.IdTipousuarioNavigation.TituloTipoUsuario
                   }
               })
               .FirstOrDefault(u => u.IdUsuario == id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações de cadastro</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Define a data de cadastro atribuindo a data no momento da solicitação
            novoUsuario.DataCadastro = DateTime.Now;

            // Adiciona um novo usuário
            ctx.Usuario.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o usuário que foi buscado através do id informado
            ctx.Usuario.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um usuário através do id
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Remove o usuário que foi buscado
            // ctx.Usuario.Remove(uUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos usuários
            //return ctx.Usuario.ToList();

            // Outra forma, não mostrando a senha
            return ctx.Usuario
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new Usuario()
               {
                   IdUsuario = u.IdUsuario,
                   NomeUsuario = u.NomeUsuario,
                   Email = u.Email,
                   Genero = u.Genero,
                   DataCadastro = u.DataCadastro,

                   IdTipousuarioNavigation = new TipoUsuario()
                   {
                       IdTipoUsuario = u.IdTipousuarioNavigation.IdTipoUsuario,
                       TituloTipoUsuario = u.IdTipousuarioNavigation.TituloTipoUsuario
                   }
               })
               .ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário autenticado</returns>
        public Usuario Login(string email, string senha)
        {
            // Busca o primeiro usuário encontrado para o e-mail e a senha informados e armazena no objeto usuarioBuscado
            Usuario usuarioBuscado = ctx.Usuario
                // Busca as informações referentes ao tipo de usuário
                .Include(u => u.IdTipousuarioNavigation)
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}

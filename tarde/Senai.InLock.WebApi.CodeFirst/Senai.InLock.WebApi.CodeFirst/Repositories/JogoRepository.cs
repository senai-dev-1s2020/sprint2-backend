using Microsoft.EntityFrameworkCore;
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
    /// Repositório dos Jogos
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            // Busca um jogo através do id
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            // Atribui os novos valores ao campos existentes
            jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
            jogoBuscado.Descricao = jogoAtualizado.Descricao;
            jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;
            jogoBuscado.Valor = jogoAtualizado.Valor;
            jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;

            // Atualiza o jogo que foi buscado
            ctx.Jogos.Update(jogoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado</returns>
        public Jogos BuscarPorId(int id)
        {
            // Retorna o primeiro jogo encontrado para o ID informado
            return ctx.Jogos.FirstOrDefault(j => j.IdJogo == id);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com as informações de cadastro</param>
        public void Cadastrar(Jogos novoJogo)
        {
            // Adiciona este novoJogo
            ctx.Jogos.Add(novoJogo);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um jogo através do id
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            // Remove o jogo que foi buscado
            ctx.Jogos.Remove(jogoBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        public List<Jogos> Listar()
        {
            // Retorna uma lista com todas as informações dos jogos
            return ctx.Jogos.ToList();
        }

        /// <summary>
        /// Lista todos os jogos com os estúdios
        /// </summary>
        /// <returns>Uma lista de jogos com os estúdios</returns>
        public List<Jogos> ListarComEstudios()
        {
            // Retorna uma lista com todas as informações dos jogos e estúdios
            return ctx.Jogos.Include(e => e.Estudio).ToList();
            // return ctx.Jogos.Include("IdEstudioNavigation").ToList();
        }

        /// <summary>
        /// Lista todos os jogos de um determinado estúdio
        /// </summary>
        /// <param name="id">ID do estúdio do qual os jogos serão listados</param>
        /// <returns>Uma lista de jogos de um determinado estúdio</returns>
        public List<Jogos> ListarUmEstudio(int id)
        {
            return ctx.Jogos.ToList().FindAll(j => j.IdEstudio == id);
        }
    }
}

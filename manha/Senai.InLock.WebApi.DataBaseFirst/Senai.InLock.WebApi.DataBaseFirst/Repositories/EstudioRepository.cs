using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    /// <summary>
    /// Repositório dos Estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Estudios estudioAtualizado)
        {
            // Busca um estúdio através do id
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            // Verifica se o nome do estúdio foi informado
            if (estudioAtualizado.NomeEstudio != null)
            {
                // Atribui os novos valores ao campos existentes
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            // Atualiza o estúdio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        public Estudios BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(Estudios novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um estúdio através do id
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Estudios.Remove(estudioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<Estudios> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        /// <summary>
        /// Lista todos os estúdios com os respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com os jogos</returns>
        public List<Estudios> ListarJogos()
        {
            // Retorna uma lista de estúdios com seus jogos
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}

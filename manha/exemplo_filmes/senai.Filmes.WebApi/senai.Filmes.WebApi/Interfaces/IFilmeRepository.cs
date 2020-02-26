using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Filme
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> Listar();

        /// <summary>
        /// Busca um filme através do ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Um objeto filme que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo recurso da requisição
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filme">Objeto filme que será atualizado</param>
        void Atualizar(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca todos os filmes que contenham uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que servirá de busca</param>
        /// <returns>Retorna uma lista de filmes encontrados</returns>
        List<FilmeDomain> BuscarPorTitulo(string busca);
    }
}

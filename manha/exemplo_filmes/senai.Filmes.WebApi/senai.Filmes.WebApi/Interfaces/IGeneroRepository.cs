using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> Listar();

        /// <summary>
        /// Busca um gênero através do ID
        /// </summary>
        /// <param name="id">ID do gênero que será buscado</param>
        /// <returns>Um objeto genero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero que será atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">ID do gênero que será atualizado</param>
        /// <param name="genero">Objeto genero que será atualizado</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="id">ID do gênero que será deletado</param>
        void Deletar(int id);
    }
}

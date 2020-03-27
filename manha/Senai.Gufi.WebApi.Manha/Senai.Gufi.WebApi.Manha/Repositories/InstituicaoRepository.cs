using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    /// <summary>
    /// Repositório responsável pelas instituições
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza uma instituição existente
        /// </summary>
        /// <param name="id">ID da instituição que será atualizada</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Instituicao instituicaoAtualizada)
        {
            // Busca uma instituição através do id
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);

            // Verifica se a instituição foi encontrada
            if (instituicaoBuscada != null)
            {
                // Verifica se foi informado um novo CNPJ para a instituição
                if (instituicaoAtualizada.Cnpj != null)
                {
                    // Atribui o novo valor ao campo
                    instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
                }

                // Verifica se foi informado um novo nome fantasia para a instituição
                if (instituicaoAtualizada.NomeFantasia != null)
                {
                    // Atribui o novo valor ao campo
                    instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
                }

                // Verifica se foi informado um novo endereço para a instituição
                if (instituicaoAtualizada.Endereco != null)
                {
                    // Atribui o novo valor ao campo
                    instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
                }

                // Atualiza os dados da instituição que foi buscada
                ctx.Instituicao.Update(instituicaoBuscada);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca uma instituição por ID
        /// </summary>
        /// <param name="id">ID da instituição que será buscada</param>
        /// <returns>Uma instituição buscada</returns>
        public Instituicao BuscarPorId(int id)
        {
            // Busca a primeira insituição encontrada para o ID informado e armazena no objeto instituicaoBuscada
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);

            // Outra forma
            // Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);

            // Verifica se a instituição foi encontrada
            if (instituicaoBuscada != null)
            {
                // Retorna a instituição encontrada
                return instituicaoBuscada;
            }

            // Caso não seja encontrada, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto com as informações de cadastro</param>
        public void Cadastrar(Instituicao novaInstituicao)
        {
            // Adiciona uma nova instituição
            ctx.Instituicao.Add(novaInstituicao);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">ID da instituição que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a instituição que foi buscada através do id informado
            ctx.Instituicao.Remove(BuscarPorId(id));

            // Outra forma

            // Busca uma instituição através do id
            // Instituicao instituicaoBuscada = ctx.Evento.Find(id);

            // Remove a instituição que foi buscada
            // ctx.Instituicao.Remove(instituicaoBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        public List<Instituicao> Listar()
        {
            // Retorna uma lista com todas as informações das instituições
            return ctx.Instituicao.ToList();
        }
    }
}

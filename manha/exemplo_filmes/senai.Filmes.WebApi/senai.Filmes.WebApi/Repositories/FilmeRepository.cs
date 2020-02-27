using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Filmes_manha; integrated security=true;";
        private string stringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um filme passando o ID pelo recurso
        /// </summary>
        /// <param name="id">ID do gênero que será atualizado</param>
        /// <param name="filme">Objeto filme que será atualizado</param>
        public void Atualizar(int id, FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Filmes SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero",filme.IdGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um filme pelo ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Um filme buscado ou null caso não seja encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFilme, Titulo, Filmes.IdGenero, Generos.Nome FROM Filmes" +
                                        " INNER JOIN Generos" +
                                        " ON Filmes.IdGenero = Generos.IdGenero" +
                                        " WHERE IdFilme = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto filme 
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdFilme o valor da coluna "IdFilme" da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Titulo o valor da coluna "Titulo" da tabela do banco
                            ,Titulo = rdr["Titulo"].ToString()

                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            ,IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            // Instancia um novo objeto do tipo GeneroDomain
                            ,Genero = new GeneroDomain
                            {
                                // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])

                                // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                                ,Nome = rdr["Nome"].ToString()
                            }
                        };

                        // Retorna o filme buscado
                        return filme;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Busca todos os filmes atavés de uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de filmes encontrados</returns>
        public List<FilmeDomain> BuscarPorTitulo(string busca)
        {
            // Cria uma lista filmes onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFilme, Titulo, Filmes.IdGenero, Generos.Nome FROM Filmes" +
                                        " INNER JOIN Generos" +
                                        " ON Filmes.IdGenero = Generos.IdGenero" +
                                        $" WHERE Titulo LIKE '%{busca}%' ORDER BY Titulo DESC";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto filme do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdFilme o valor da coluna IdFilme da tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Titulo o valor da coluna Titulo da tabela do banco de dados
                            ,Titulo = rdr["Titulo"].ToString()

                            // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                            ,IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            // Instancia um novo objeto do tipo GeneroDomain 
                            ,Genero = new GeneroDomain
                            {
                                // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])

                                // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                                ,Nome = rdr["Nome"].ToString()
                            }
                        };

                        // Adiciona o filme criado à lista filmes
                        filmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de filmes
            return filmes;
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme que será cadastrado</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Filmes(Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Filmes WHERE IdFilme = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        public List<FilmeDomain> Listar()
        {
            // Cria uma lista filmes onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFilme, Titulo, Filmes.IdGenero, Generos.Nome FROM Filmes" +
                                        " INNER JOIN Generos" +
                                        " ON Filmes.IdGenero = Generos.IdGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto filme do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdFilme o valor da coluna IdFilme da tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Titulo o valor da coluna Titulo da tabela do banco de dados
                            ,Titulo = rdr["Titulo"].ToString()

                            // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                            ,IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            //Instancia um novo objeto do tipo GeneroDomain
                            ,Genero = new GeneroDomain
                            {
                                // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])

                                // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                                ,Nome = rdr["Nome"].ToString()
                            }
                        };

                        // Adiciona o filme criado à lista filmes
                        filmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de filmes
            return filmes;
        }
    }
}
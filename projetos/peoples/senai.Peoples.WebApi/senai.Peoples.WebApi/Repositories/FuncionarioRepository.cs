using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos Funcionários
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Peoples; integrated security=true;";
        private string stringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um funcionário existente
        /// </summary>
        /// <param name="id">ID do funcionário que será atualizado</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado que será atualizado</param>
        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios " +
                                     "SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento " +
                                     "WHERE IdFuncionario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionarioAtualizado.DataNascimento);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionários com os nomes completos
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        public List<FuncionarioDomain> ListarNomeCompleto()
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, CONCAT (Nome, ' ', Sobrenome), DataNascimento FROM Funcionarios";

                // Outra forma
                //string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

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
                        // Instancia um objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna IdFuncionario da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome os valores das colunas Nome e Sobrenome da tabela do banco de dados
                            ,Nome = rdr[1].ToString()

                            // Outra forma
                            //,Nome = rdr["Nome"].ToString() + ' ' + rdr["Sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna DataNascimento da tabela do banco de dados
                            ,DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o filme criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        /// <summary>
        /// Busca um funcionário através do ID
        /// </summary>
        /// <param name="id">ID do funcionário que será buscado</param>
        /// <returns>Retorna um funcionário buscado</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios" +
                                        " WHERE IdFuncionario = @ID";

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
                        // Instancia um objeto funcionario 
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,Nome = rdr["Nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            ,Sobrenome = rdr["Sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna "DataNascimento" da tabela do banco
                            ,DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Retorna o funcionário buscado
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Busca uma lista de funcionários através do nome
        /// </summary>
        /// <param name="nome">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de funcionários encontrados</returns>
        public List<FuncionarioDomain> BuscarPorNome(string nome)
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios" +
                                        $" WHERE Nome LIKE '%{nome}%'";

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
                        // Instancia um objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna IdFuncionario da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            ,Nome = rdr["Nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna Sobrenome da tabela do banco de dados
                            ,Sobrenome = rdr["Sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna DataNascimento da tabela do banco de dados
                            ,DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o filme criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario que será cadastrado</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento) " +
                                     "VALUES (@Nome, @Sobrenome, @DataNascimento)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", novoFuncionario.DataNascimento);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um funcionário existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

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
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        public List<FuncionarioDomain> Listar()
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

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
                        // Instancia um objeto funcionario 
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,Nome = rdr["Nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            ,Sobrenome = rdr["Sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna "DataNascimento" da tabela do banco
                            ,DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o funcionario criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        /// <summary>
        /// Lista todos os funcionários de maneira ordenada pelo nome
        /// </summary>
        /// <param name="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de funcionários</returns>
        public List<FuncionarioDomain> ListarOrdenado(string ordem)
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento " +
                                        $"FROM Funcionarios ORDER BY Nome {ordem}";

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
                        // Instancia um objeto funcionario 
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Nome = rdr["Nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            ,
                            Sobrenome = rdr["Sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna "DataNascimento" da tabela do banco
                            ,
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o funcionario criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }
    }
}

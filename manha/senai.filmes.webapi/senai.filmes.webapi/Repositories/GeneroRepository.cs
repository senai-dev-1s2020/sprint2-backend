using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }
    }
}

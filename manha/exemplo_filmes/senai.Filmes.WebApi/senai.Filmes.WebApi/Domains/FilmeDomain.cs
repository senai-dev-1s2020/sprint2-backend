using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que representa a tabela Filmes
/// </summary>
namespace senai.Filmes.WebApi.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public string Titulo { get; set; }

        public int IdGenero { get; set; }

        public GeneroDomain Genero { get; set; }
    }
}

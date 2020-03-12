using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Generos
    {
        public Generos()
        {
            Filmes = new HashSet<Filmes>();
        }

        public int IdGenero { get; set; }
        public string Nome { get; set; }

        public ICollection<Filmes> Filmes { get; set; }
    }
}

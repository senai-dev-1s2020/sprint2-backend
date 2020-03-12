using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Filmes
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int? IdGenero { get; set; }

        public Generos IdGeneroNavigation { get; set; }
    }
}

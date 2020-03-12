using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}

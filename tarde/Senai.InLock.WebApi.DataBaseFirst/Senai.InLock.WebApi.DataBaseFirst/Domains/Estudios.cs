using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Estudios
    /// </summary>
    public partial class Estudios
    {
        public Estudios()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int IdEstudio { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string NomeEstudio { get; set; }

        public ICollection<Jogos> Jogos { get; set; }
    }
}

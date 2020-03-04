using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade Estudios
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string NomeEstudio { get; set; }

        public List<JogoDomain> Jogos { get; set; }
    }
}

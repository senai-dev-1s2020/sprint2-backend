using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade TipoEvento
    /// </summary>
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O título do tipo de evento é obrigatório!")]
        public string TituloTipoEvento { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}

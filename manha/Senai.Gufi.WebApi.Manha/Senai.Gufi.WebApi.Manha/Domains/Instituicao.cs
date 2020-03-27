using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Instituicao
    /// </summary>
    public partial class Instituicao
    {
        public Instituicao()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O CNPJ da instituição é obrigatório!")]
        public string Cnpj { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o nome fantasia da instituição!")]
        public string NomeFantasia { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o endereço da instituição!")]
        public string Endereco { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}

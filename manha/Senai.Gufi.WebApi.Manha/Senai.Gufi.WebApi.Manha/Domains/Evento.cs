using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Evento
    /// </summary>
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "É necessário informar a data e hora do evento!")]
        public DateTime DataEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do evento é obrigatório!")]
        public string Descricao { get; set; }

        public bool? AcessoLivre { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O id da instituição onde o evento ocorrerá é obrigatório!")]
        public int IdInstituicao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o id do tipo de evento")]
        public int IdTipoEvento { get; set; }

        public Instituicao IdInstituicaoNavigation { get; set; }
        public TipoEvento IdTipoEventoNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}

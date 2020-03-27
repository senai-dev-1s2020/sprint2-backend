using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Presenca
    /// </summary>
    public partial class Presenca
    {
        public int IdPresenca { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Necessário informar o id do usuário que participará do evento")]
        public int IdUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Necessário informar o id do evento que o usuário participará")]
        public int IdEvento { get; set; }

        public string Situacao { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}

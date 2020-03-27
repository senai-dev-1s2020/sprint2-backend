using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>
    public partial class Usuario
    {
        public Usuario()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        public string NomeUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos do campo
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 50 caracteres")]
        public string Senha { get; set; }

        public DateTime? DataCadastro { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O campo é obrigatório (insira 'prefiro não informar', se for o caso)")]
        public string Genero { get; set; }

        public int? IdTipousuario { get; set; }

        public TipoUsuario IdTipousuarioNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}

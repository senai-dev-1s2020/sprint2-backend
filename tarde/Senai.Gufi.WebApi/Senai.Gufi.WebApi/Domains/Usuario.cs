using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Domains
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

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O campo é obrigatório (insira 'prefiro não informar', se for o caso)")]
        public string Genero { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de nascimento do usuário é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public int? IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}

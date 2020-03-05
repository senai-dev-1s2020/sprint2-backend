using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.DataBaseFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define os requisitos do campo
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}

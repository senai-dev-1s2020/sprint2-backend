using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        // Define que o formato e que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que o campo é obrigatório, com no mínimo 3 caracteres e no máximo 20 caracteres
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 caracteres")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}

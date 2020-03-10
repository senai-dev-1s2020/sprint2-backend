using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>
    
    // Define o nome da tabela que será criada no banco de dados
    [Table("Usuarios")]
    public class Usuarios
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigátória
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos da propriedade
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        // Define a chave estrangeira
        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario TipoUsuario { get; set; }
    }
}

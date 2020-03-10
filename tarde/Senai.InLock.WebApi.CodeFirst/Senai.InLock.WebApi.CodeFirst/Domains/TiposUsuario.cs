using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposUsuario
    /// </summary>

    // Define o nome da tabela que será criada no banco de dados
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(255)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string Titulo { get; set; }
    }
}

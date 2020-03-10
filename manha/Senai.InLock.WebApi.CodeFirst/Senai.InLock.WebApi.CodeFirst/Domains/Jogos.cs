using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogos
    /// </summary>

    // Define o nome da tabela que será criada no banco de dados
    [Table("Jogos")]
    public class Jogos
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJogo { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string NomeJogo { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "TEXT")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string Descricao { get; set; }

        // Define o tipo de dado que será criado no banco
        [Column(TypeName = "DATE")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        // Define o nome da coluna e o tipo de dado
        [Column("Preco", TypeName = "DECIMAL (18,2)")]
        // Define o tipo do dado
        [DataType(DataType.Currency)]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o preço do jogo!")]
        public decimal Valor { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo!")]
        public int IdEstudio { get; set; }

        // Define a chave estrangeira
        [ForeignKey("IdEstudio")]
        public Estudios Estudio { get; set; }
    }
}

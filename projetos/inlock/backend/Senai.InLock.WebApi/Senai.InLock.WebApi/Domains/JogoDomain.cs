using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade Jogos
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string NomeJogo { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string Descricao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o preço do jogo!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo!")]
        public int IdEstudio { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}

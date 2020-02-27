using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        // Define que o nome do funcionário precisa ser informado
        [Required(ErrorMessage = "O nome do funcionário é obrigatório")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        // Define que a data de nascimento precisa ser informada
        [Required(ErrorMessage = "Informe a data de nascimento do funcionário")]
        // Define o tipo de dado
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}

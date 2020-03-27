using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.ViewModels
{
    /// <summary>
    /// Classe responsável pelo modelo de Login
    /// </summary>
    public class LoginViewModel
    {
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}

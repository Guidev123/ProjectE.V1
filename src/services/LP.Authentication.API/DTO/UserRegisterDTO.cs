using System.ComponentModel.DataAnnotations;

namespace LP.Authentication.API.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} foi digitado em formato inválido")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} foi digitado em formato inválido", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

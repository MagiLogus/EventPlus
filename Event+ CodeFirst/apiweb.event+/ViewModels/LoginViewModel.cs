using System.ComponentModel.DataAnnotations;

namespace apiweb.event_.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuário!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 digitos")]
        public string? Senha { get; set; }
    }
}

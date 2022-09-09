using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserRegisterViewModel : UserViewModel
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [MinLength(4, ErrorMessage = "{0} de conter no mínimo {1} caracteres")]
        [MaxLength(15, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Password { get; set; }
    }
}

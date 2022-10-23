using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserLoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public string Password { get; set; }
    }
}
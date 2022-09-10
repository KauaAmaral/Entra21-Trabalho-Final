using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserChangePasswordViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Senha atual")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public string CurrentPassword { get; set; }

        [Display(Name = "Senha nova")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar senha nova")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [Compare("NewPassword", ErrorMessage = "Senha não confere com nova senha")]
        public string ConfirmNewPassword { get; set; }
    }
}
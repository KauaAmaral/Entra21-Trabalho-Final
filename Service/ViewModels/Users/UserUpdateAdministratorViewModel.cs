using Entra21.CSharp.Area21.Repository.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserUpdateAdministratorViewModel : UserUpdateViewModel
    {
        [Display(Name = "Senha")]
        [MinLength(4, ErrorMessage = "{0} de conter no mínimo {1} caracteres")]
        [MaxLength(15, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string? Password { get; set; }

        [Display(Name = "Confirmar senha nova")]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "ID de identificação")]
        public UserHierarchy HierarchyId { get; set; }
        public string? TypeName { get; set; }

        [Display(Name = "ID de identificação do guarda")]
        public string? IdentificationId { get; set; }
    }
}
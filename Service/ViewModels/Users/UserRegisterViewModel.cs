using Entra21.CSharp.Area21.Repository.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "{0} deve ser completo")]
        [MinLength(2, ErrorMessage = "{0} de conter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "{0} deve ser preenchido no formato correto")]
        public string Email { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "{0} deve ser preenchido no formato '000.000.000-00'")]
        public string Cpf { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [MinLength(4, ErrorMessage = "{0} de conter no mínimo {1} caracteres")]
        [MaxLength(15, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha nova")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string ConfirmPassword { get; set; }
        public Guid Token { get; set; }
        public DateTime TokenExpiredDate { get; set; }
        public UserHierarchy Hierarchy { get; set; }
    }
}

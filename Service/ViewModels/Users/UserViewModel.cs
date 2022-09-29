using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users
{
    public class UserViewModel
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

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\([1-9]{2}\) [0-9]{5}\-[0-9]{4}$", ErrorMessage = "{0} deve ser preenchido no formato '(99) 99999-9999'")]
        public string? Phone { get; set; }
    }
}

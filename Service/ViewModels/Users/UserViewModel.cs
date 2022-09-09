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
        public string Email { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public string Cpf { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "{0} deve ser completo")]
        public string Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email != null && IsValidEmail())
            {
                yield return new ValidationResult(
                   "Email deve conter um e-mail válido",
                   new[] { Name = "Email" });
            }

            if (Phone != null && IsValidPhone())
            {
                yield return new ValidationResult(
                    "Telefone deve conter um telefone no formato (00) 00000-0000",
                    new[] { Name = "Celular" });
            }

            if (Cpf != null && IsValidCpf())
            {
                yield return new ValidationResult(
                    "CPF deve conter um CPF no formato 000.000.000-00",
                     new[] { Name = "CPF" });
            }
        }

        private bool IsValidEmail() =>
            !Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private bool IsValidPhone() =>
            !Regex.IsMatch(Phone, @"^\([1-9]{2}\) [0-9]{5}\-[0-9]{4}$");   
        private bool IsValidCpf() =>
            !Regex.IsMatch(Phone, @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Guards
{
    public class GuardViewModel
    {
        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} de ser preenchido")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "{0} deve ser preenchido no formato '000.000.000-00'")]
        public string Cpf { get; set; }

        [Display(Name = "Número de identificação")]
        [Required(ErrorMessage = "{0} de ser preenchido")]
        [MaxLength(10, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string IdentificationNumber { get; set; }

        public int? UserId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Guards
{
    public class GuardViewModel
    {
        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} de ser preenchido")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "{0} deve ser preenchido no formato '000.000.000-00'")]
        public string Cpf { get; set; }
        
        // TODO: Verificar no register do guard, para retornar o usuario na tela
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }

        [Display(Name = "Número de Identificação")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string IdentificationNumber { get; set; }
    }
}

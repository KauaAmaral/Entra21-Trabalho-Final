using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Guards
{
    public class GuardViewModel
    {
        // TODO: Atualizar Kauã/Wellington
        [Display(Name = "Número de Identificação")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }
    }
}

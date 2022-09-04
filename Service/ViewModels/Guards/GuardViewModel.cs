using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Guards
{
    public class GuardViewModel
    {
        [Display(Name = "Número de Identificação")]
        [Required(ErrorMessage = "{0} deve ser preenchido corretamente")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }

        public IFormFile? File { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Notifications
{
    public class NotificationViewModel
    {
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(5, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Address { get; set; }
    }
}
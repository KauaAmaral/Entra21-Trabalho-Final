using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Payments
{
    public class PaymentViewModel
    {
        [Display(Name = "Veiculo")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? VehicleId { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }
        public IFormFile? File { get; set; }
    }
}

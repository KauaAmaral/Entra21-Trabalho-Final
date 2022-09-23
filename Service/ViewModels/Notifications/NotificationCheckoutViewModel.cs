using Entra21.CSharp.Area21.Repository.Entities.Paypal.PaypalTransaction;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Notifications
{
    internal class NotificationCheckoutViewModel : NotificationViewModel
    {
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string LicensePlate { get; set; }
    }
}

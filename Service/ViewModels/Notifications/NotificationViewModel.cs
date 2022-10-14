using Entra21.CSharp.Area21.Repository.Enums;
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

        [Display(Name = "Placa do Veículo")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string VehiclePlate { get; set; }

        [Display(Name = "Observações")]
        public string? Comments { get; set; }

        [Display(Name = "Tipo do veículo: ")]
        public VehicleType Type { get; set; }

        public bool Registered { get; set; }
        
        public int? NotificationAmount { get; set; }
       
        public string? Token { get; set; }
        public string? PayerId { get; set; }
        public string? TransactionId { get; set; }
        public decimal? Value { get; set; }
        
        public int GuardId { get; set; }
        public int? VehicleId { get; set; }
    }    
}
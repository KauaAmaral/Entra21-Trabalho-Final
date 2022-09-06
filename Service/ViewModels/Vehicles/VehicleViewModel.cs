using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Vehicles
{
    public class VehicleViewModel // TODO Fazer as Validacao do VehicleViewModel
    {
        [Display(Name = "Letras e números da placa")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string LicensePlate { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }
    }
}

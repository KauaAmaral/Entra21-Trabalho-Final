using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Vehicles
{
    public class VehicleViewModel // TODO Fazer as Validacao do VehicleViewModel
    {
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string LicensePlate { get; set; }

        [Display(Name = "Modelo do veículo")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(6, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Model { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        public int? UserId { get; set; }

        [Display(Name = "Tipo do veículo: ")]
        public byte Type { get; set; }

    }
}

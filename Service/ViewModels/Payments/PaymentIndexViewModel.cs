namespace Entra21.CSharp.Area21.Service.ViewModels.Payments
{
    public class PaymentIndexViewModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public Enum Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
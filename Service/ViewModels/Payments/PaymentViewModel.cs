using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.Area21.Service.ViewModels.Payments
{
    public class PaymentViewModel
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string PayerId { get; set; }
        public string TransactionId { get; set; }
        public decimal Value { get; set; }
    }
}

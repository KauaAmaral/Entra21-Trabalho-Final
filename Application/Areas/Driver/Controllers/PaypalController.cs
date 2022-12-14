using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Application.Models.PaypalOrder;
using Entra21.CSharp.Area21.Application.Models.PaypalTransaction;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [IsUserLogged]
    [IsDriver]
    [Area("Driver")]
    [Route("driver/paypal")]
    public class PaypalController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;
        private readonly ISessionAuthentication _session;

        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com"; //https://area21.azurewebsites.net

        public PaypalController(
            IVehicleService vehicleService,
            IPaymentService paymentService,
            ISessionAuthentication sessionAuthentication)
        {
            _vehicleService = vehicleService;
            _paymentService = paymentService;
            _session = sessionAuthentication;
        }

        [HttpPost]
        public async Task<JsonResult> Paypal(string id)
        {
            var link = GetUrl();

            var urlCancel = Request.Scheme + "://" + Request.Host + "/driver/Home";

            var IdVehicle = Convert.ToInt32(id);

            var price = "";

            var vehicle = _vehicleService.GetById(IdVehicle);
            var product = vehicle.LicensePlate;

            var idUser = vehicle.UserId;

            if (vehicle.Type == 0)
                price = "1.50";
            else
                price = "0.75";

            var status = false;
            var answer = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                var authToken = Encoding.ASCII.GetBytes($"{_userName}:{_passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var urlReturn = link + $"/driver/Paypal/Approved?idVehicle={IdVehicle}&IdUser={idUser}";
                var orden = new PaypalOrder()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<Models.PaypalOrder.PurchaseUnit>() {

                        new Models.PaypalOrder.PurchaseUnit() {

                            amount = new Models.PaypalOrder.Amount() {
                                currency_code = "BRL",
                                value = price
                            },
                            description = product
                        }
                    },
                    application_context = new ApplicationContext()
                    {
                        brand_name = "Area21",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW",
                        return_url = urlReturn,
                        cancel_url = urlCancel
                    }
                };

                var json = JsonConvert.SerializeObject(orden);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

                status = response.IsSuccessStatusCode;

                if (status)
                {
                    answer = response.Content.ReadAsStringAsync().Result;
                }
            }
            return Json(new { status = status, response = answer });
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved([FromQuery] int idVehicle, int idUser, string token, string PayerID)
        {

            var status = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                var authToken = Encoding.ASCII.GetBytes($"{_userName}:{_passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var data = new StringContent("{}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"/v2/checkout/orders/{token}/capture", data);

                status = response.IsSuccessStatusCode;

                ViewData["Status"] = status;
                if (status)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;

                    var objeto = JsonConvert.DeserializeObject<PaypalTransaction>(jsonResponse);

                    ViewData["IdTransaccion"] = objeto.purchase_units[0].payments.captures[0].id;

                    var viewModel = new PaymentRegisterViewModel
                    {
                        VehicleId = idVehicle,
                        UserId = idUser,
                        Token = token,
                        PayerId = PayerID,
                        TransactionId = objeto.purchase_units[0].payments.captures[0].id,
                        Value = Convert.ToDecimal(objeto.purchase_units[0].payments.captures[0].amount.value.Replace(".", ","))
                    };

                    _paymentService.Register(viewModel);
                }
            }
            return View();
        }

        private string GetUrl()
        {
            var https = Request.Scheme; 
            var caminho = Request.Host; 
          
            return (https + "://" + caminho);
        }

        [HttpPost("Approved")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("setLocation")]
        public void SetLocation(string longitude, string latitude, string transactionId)
        {
            var viewModel = new PaymentUpdateViewModel
            {
                TransactionId = transactionId,
                Latitude = latitude,
                Longitude = longitude
            };

            _paymentService.UpdateLocation(viewModel);
        }
    }
}
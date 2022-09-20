using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Application.Models.PaypalOrder;
using Entra21.CSharp.Area21.Application.Models.PaypalTransaction;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/paypal")]
    public class PaypalController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;
        private readonly ISessionAuthentication _session;

        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com";
        private readonly string _urlReturn = "https://localhost:7121/driver/Paypal/Approved";
        private readonly string _urlCancel = "https://localhost:7121/driver/Home";

        public PaypalController(
            IVehicleService vehicleService,
            ISessionAuthentication sessionAuthentication
            )
        {
            _vehicleService = vehicleService;
            _session = sessionAuthentication;
        }

        public IActionResult Index()
        {
            return View("Teste");
        }

        [Route("approved")]
        public async Task<IActionResult> Approved()
        {
            var token = HttpContext.Request.Query["token"];

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
                    var jsonRespuesta = response.Content.ReadAsStringAsync().Result;

                    PaypalTransaction objeto = JsonConvert.DeserializeObject<PaypalTransaction>(jsonRespuesta);

                    ViewData["IdTransaccion"] = objeto.purchase_units[0].payments.captures[0].id;
                }
            }
            return View();
        }

        [HttpPost("Paypal")]
        public async Task<JsonResult> Paypal(string id)
        {
            var vehicleId = Convert.ToInt32(id);

            var price = 1.10;

            var vehicle = _vehicleService.GetById(vehicleId);
            var product = vehicle.LicensePlate;

            if (vehicle.Type == 0)
                price = 1.00;
            else
                price = 0.75;

            bool status = false;
            string answer = string.Empty;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                var authToken = Encoding.ASCII.GetBytes($"{_userName}:{_passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));


                var orden = new PaypalOrder()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<Models.PaypalOrder.PurchaseUnit>() {

                        new Models.PaypalOrder.PurchaseUnit() {

                            amount = new Models.PaypalOrder.Amount() {
                                currency_code = "BRL",
                                value = price.ToString()
                            },
                            description = product
                        }
                    },
                    application_context = new ApplicationContext()
                    {
                        brand_name = "Area21",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW", //Accion para que paypal muestre el monto de pago
                        return_url = _urlReturn,
                        cancel_url = _urlCancel
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
            return Json(new { status = status, respuesta = answer });
        }

        [HttpPost("Approved")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

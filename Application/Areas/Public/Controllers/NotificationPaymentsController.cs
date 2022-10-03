using Entra21.CSharp.Area21.Application.Models.PaypalOrder;
using Entra21.CSharp.Area21.Application.Models.PaypalTransaction;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Entra21.CSharp.Area21.Application.Areas.Public.Controllers
{
    [Area("Public")]
    [Route("Public/paypal")]
    public class NotificationPaymentsController : Controller
    {
        private readonly INotificationService _notificationService;

        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com";
        private readonly string _urlCancel = "https://localhost:7121/driver/Home"; //TUDO Trocar rotas

        public NotificationPaymentsController(
            INotificationService notificationService
            )
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View("Teste");
        }

        [HttpPost("Paypal")]
        public async Task<JsonResult> Paypal(string id)
        {
            var idNotificaton = Convert.ToInt32(id);
            var notification = _notificationService.GetById(idNotificaton);
            
            bool status = false;
            string answer = string.Empty;

            string urlReturn = $"https://localhost:7121/Public/NotificationPayments/Approved?idNotification={notification.Id}&IdGuard={notification.GuardId}";

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
                                value = (notification.Value).ToString()
                            },
                            description = notification.VehicleLicensePlate
                        }
                    },
                    application_context = new ApplicationContext()
                    {
                        brand_name = "Area21",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW",
                        return_url = urlReturn,
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
            return Json(new { status = status, response = answer });
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved([FromQuery] int idNotification, int idGuard, string token, string PayerID)//TUDO REFATORAR
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

                    var viewModel = new NotificationUpdateViewModel//TUDO INFORMAR O AI DO CAMPO
                    {
                        Token = token,
                        PayerId = PayerID,
                        TransactionId = objeto.purchase_units[0].payments.captures[0].id,
                    };

                    _notificationService.Update(viewModel);
                }
            }
            return View();
        }

        [HttpPost("Approved")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

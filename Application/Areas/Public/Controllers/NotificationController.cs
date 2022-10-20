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
    [Route("Public/Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com";
        

        public NotificationController(
            INotificationService notificationService
            )
        {
            _notificationService = notificationService;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Check")]
        public IActionResult Check([FromQuery] int id)
        {
            var notification = _notificationService.GetById(id);

            if (notification == null)
                return RedirectToAction("Home");

            var notificationCheckoutViewModal = new NotificationCheckoutViewModel
            {
                Id = notification.Id,
                VehiclePlate = notification.VehicleLicensePlate,
                Status = notification.Status,
                Value = notification.Value,
                Address = notification.Address,
                CreatedAt = notification.CreatedAt,
                UpdatedAt = notification.UpdatedAt
            };

            return View("notification/check", notificationCheckoutViewModal);
        }

        [HttpPost("Paypal")]
        public async Task<JsonResult> Paypal(string id)
        {
            var urlCancel = Request.Scheme + "://" + Request.Host + "driver/Home";
            var idNotificaton = Convert.ToInt32(id);

            var notification = _notificationService.GetById(idNotificaton);

            bool status = false;
            string answer = string.Empty;

            if (notification.Token != null || notification.CreatedAt.Date > notification.CreatedAt.Date.AddDays(15))
                return Json(new { status = status, response = answer });

            string urlReturn = Request.Scheme + "://" + Request.Host + $"Public/Notification/Approved?id={notification.Id}";

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
                                value = (notification.Value).ToString().Replace(",",".")
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
        public async Task<IActionResult> Approved([FromQuery] int id, string token, string PayerID)//TUDO REFATORAR
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

                    var notification = _notificationService.GetById(id);

                    var viewModel = new NotificationUpdateViewModel
                    {
                        Id = id,
                        Token = token,
                        PayerId = PayerID,
                        TransactionId = objeto.purchase_units[0].payments.captures[0].id,
                    };

                    _notificationService.Update(viewModel);
                }
            }
            return Ok();
        }

        [HttpPost("Approved")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

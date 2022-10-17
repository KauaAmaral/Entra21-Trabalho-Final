using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Application.Models.PaypalOrder;
using Entra21.CSharp.Area21.Application.Models.PaypalTransaction;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Entra21.CSharp.Area21.Application.Areas.Guard.Controllers
{
    [IsUserLogged]
    [IsGuard]
    [Area("Guard")]
    [Route("/Guard/Notification/")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;
        private readonly ISessionAuthentication _session;
        private readonly IGuardService _guardService;
        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com";
        private readonly string _urlCancel = "https://localhost:7121/driver/Home";

        public NotificationController(
            INotificationService notificationService,
            IVehicleService vehicleService,
            IGuardService guardService,
            IPaymentService paymentService,
            ISessionAuthentication sessionAuthentication

            )
        {
            _notificationService = notificationService;
            _vehicleService = vehicleService;
            _paymentService = paymentService;
            _session = sessionAuthentication;
            _guardService = guardService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();

            return View("Index", notifications);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] NotificationUpdateViewModel notificationUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var update = _notificationService.Update(notificationUpdateViewModel);

            return Ok(new { status = update });
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetAll();

            return Ok(notifications);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var notifications = _notificationService.GetById(id);

            return Ok(notifications);
        }

        [HttpGet("register")]
        public IActionResult Register([FromQuery] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            var plate = notificationRegisterViewModel.VehiclePlate;
            var vehicle = _vehicleService.GetByVehiclePlate(plate);
            var validPayment = false;
            if (vehicle != null)
                validPayment = _paymentService.ValidPayment(vehicle);

            if (!validPayment)
            {
                if (vehicle == null)
                {
                    notificationRegisterViewModel.Registered = false;
                    ViewBag.VehicleType = GetVehicleType();
                }
                else
                {
                    notificationRegisterViewModel.VehiclePlate = vehicle.LicensePlate;
                    notificationRegisterViewModel.Type = vehicle.Type;
                    notificationRegisterViewModel.Registered = true;
                    var vehicleType = GetVehicleType();
                    ViewBag.VehicleType = vehicleType;
                }

                return View("Register", notificationRegisterViewModel);
            }
            else
            {
                return RedirectToAction("Checkout");
            }
        }

        [HttpPost("registerNotification")]
        public IActionResult RegisterNotification([FromForm] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            var user = _session.FindUserSession();

            if (user != null)
                notificationRegisterViewModel.GuardId = _guardService.GetByUserId(user.Id).Id;
            else
                return RedirectToAction("Index", "Home");

            var vehicle = _vehicleService.GetByVehiclePlate(notificationRegisterViewModel.VehiclePlate);

            if (vehicle != null)
            {
                notificationRegisterViewModel.VehicleId = vehicle.Id;
            }

            if (!ModelState.IsValid)
            {
                ViewBag.VehicleType = GetVehicleType();
                return View(notificationRegisterViewModel);
            }

            var notification = _notificationService.SetNotification(notificationRegisterViewModel);

            var link = Url.ActionLink("Notification", "Paypal");

            link += $"?id={notification.Id}";

            _notificationService.CreatePdfNotifications(notification, link);

            return RedirectToAction("Checkout");
        }

        [HttpGet("checkout")]
        public IActionResult Checkout()
        {
            return View("Checkout");
        }

        private List<string> GetVehicleType()
        {
            return Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("paypal")]
        public async Task<JsonResult> Paypal(string id)
        {
            var idNotification = Convert.ToInt32(id);

            var price = "";

            var notification = _notificationService.GetById(idNotification);
            var product = notification.VehicleLicensePlate;

            notification.Vehicle = new Vehicle();

            if (notification.Vehicle.Type == 0)
                price = "7.50";
            else
                price = "4.75";

            var status = false;
            var answer = string.Empty;

            var _urlReturn = $"https://localhost:7121/driver/Paypal/Approved?idNotification={idNotification}";

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
            return Json(new { status = status, response = answer });
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved([FromQuery] int idNotification, string token, string PayerID)
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

                    var viewModel = new NotificationUpdateViewModel
                    {
                        Id = idNotification,
                        Token = token,
                        PayerId = PayerID,
                        TransactionId = objeto.purchase_units[0].payments.captures[0].id,
                        Value = Convert.ToDecimal(objeto.purchase_units[0].payments.captures[0].amount.value.Replace(".", ","))
                    };

                    _notificationService.Update(viewModel);
                }
            }
            return View();
        }
    }
}
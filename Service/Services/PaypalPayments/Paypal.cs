//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entra21.CSharp.Area21.Service.Services.PaypalPayments
//{
//    internal class Paypal
//    {

//        [HttpPost]
//        //public JsonResult Paypal(string precio) ---> EDITAR POR LA LINEA DE ABAJO
//        public async Task<JsonResult> Paypal(string precio, string producto)
//        {

//            bool status = false;
//            string respuesta = string.Empty;

//            using (var client = new HttpClient())
//            {

//                //INGRESA TUS CREDENCIALES AQUI -> CLIENT ID - SECRET
//                var userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
//                var passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";

//                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");

//                var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));


//                var orden = new PaypalOrder()
//                {
//                    intent = "CAPTURE",
//                    purchase_units = new List<Models.PurchaseUnit>() {

//                        new Models.PurchaseUnit() {

//                            amount = new Models.Amount() {
//                                currency_code = "BRL",
//                                value = precio
//                            },
//                            description = producto
//                        }
//                    },
//                    application_context = new ApplicationContext()
//                    {
//                        brand_name = "Mi Tienda",
//                        landing_page = "NO_PREFERENCE",
//                        user_action = "PAY_NOW", //Accion para que paypal muestre el monto de pago
//                        return_url = "https://localhost:44321/Home/About",// cuando se aprovo la solicitud del cobro
//                        cancel_url = "https://localhost:44321/Home/Index"// cuando cancela la operacion
//                    }
//                };

//                var json = JsonConvert.SerializeObject(orden);
//                var data = new StringContent(json, Encoding.UTF8, "application/json");

//                HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

//                status = response.IsSuccessStatusCode;

//                if (status)
//                {
//                    respuesta = response.Content.ReadAsStringAsync().Result;
//                }

//            }

//            return Json(new { status = status, respuesta = respuesta });

//        }
//    }
//}
//}

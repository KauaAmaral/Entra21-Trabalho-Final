using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Entities.Paypal.PaypalOrder;
using Entra21.CSharp.Area21.Repository.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Service.Services.Paypal
{


    public class PaypalService
    {
        //Inform your credential

        private readonly string _UserName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _Passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _Url = "https://api-m.sandbox.paypal.com";
        private readonly string _UrlReturn = "https://localhost:44321/Home/About";
        private readonly string _UrlCancel = "https://localhost:44321/Home/Index";

        public void CreatJsonPaypal(Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            double preci;
            var product = (VehicleType)vehicle.Type;

            if (vehicle.Type == 0)
                preci = 1.00;
            else
                preci = 0.75;

            bool status = false;
            string respuesta = string.Empty;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Url);

                var authToken = Encoding.ASCII.GetBytes($"{_UserName}:{_Passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));


                var orden = new PaypalOrder()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<PurchaseUnit>() {

                        new PurchaseUnit() {

                            amount = new Amount() {
                                currency_code = "BRL",
                                value = ""+preci
                            },
                            description = ""+product
                        }
                    },
                    application_context = new ApplicationContext()
                    {
                        brand_name = "Mi Tienda",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW",
                        return_url = _UrlReturn,
                        cancel_url = _UrlCancel
                    }
                };

                var json = JsonConvert.SerializeObject(orden);

                sadas();
            }
        }


        public void sadas()
        {
            //bool status = false;
            //string respuesta = string.Empty;


            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

            //status = response.IsSuccessStatusCode;

            //if (status)
            //{
            //    respuesta = response.Content.ReadAsStringAsync().Result;
            //}



            //return new JsonResult(status, respuesta);

        }
    }
}


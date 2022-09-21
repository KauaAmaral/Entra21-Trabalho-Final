namespace Entra21.CSharp.Area21.Repository.Entities.Paypal.PaypalTransaction
{
    public class PaypalTransaction
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<PurchaseUnit> purchase_units { get; set; }
        public Payer payer { get; set; }
        public List<Link> links { get; set; }

    }
    public class Name
    {
        public string full_name { get; set; }
        public string given_name { get; set; }
        public string surname { get; set; }
    }
    public class Address
    {
        public string address_line_1 { get; set; }
        public string admin_area_2 { get; set; }
        public string admin_area_1 { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }
    public class Shipping
    {
        public Name name { get; set; }
        public Address address { get; set; }
    }
    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }
    public class SellerProtection
    {
        public string status { get; set; }
        public List<string> dispute_categories { get; set; }
    }
    public class GrossAmount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }
    public class PaypalFee
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }
    public class NetAmount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }
    public class SellerReceivableBreakdown
    {
        public GrossAmount gross_amount { get; set; }
        public PaypalFee paypal_fee { get; set; }
        public NetAmount net_amount { get; set; }
    }
    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }
    public class Capture
    {
        public string id { get; set; }
        public string status { get; set; }
        public Amount amount { get; set; }
        public bool final_capture { get; set; }
        public SellerProtection seller_protection { get; set; }
        public SellerReceivableBreakdown seller_receivable_breakdown { get; set; }
        public List<Link> links { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
    }
    public class Payments
    {
        public List<Capture> captures { get; set; }
    }
    public class PurchaseUnit
    {
        public string reference_id { get; set; }
        public Shipping shipping { get; set; }
        public Payments payments { get; set; }
    }
    public class Payer
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public string payer_id { get; set; }
        public Address address { get; set; }
    }
}
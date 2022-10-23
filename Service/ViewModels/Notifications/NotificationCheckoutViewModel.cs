namespace Entra21.CSharp.Area21.Service.ViewModels.Notifications
{
    public class NotificationCheckoutViewModel : NotificationViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
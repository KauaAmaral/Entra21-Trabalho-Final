namespace Entra21.CSharp.Area21.Service.Email
{
    public interface IEmail
    {
        public bool SendEMail (string email, string subject, string message);
    }
}

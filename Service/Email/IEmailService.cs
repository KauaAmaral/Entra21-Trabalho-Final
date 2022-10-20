namespace Entra21.CSharp.Area21.Service.Email
{
    public interface IEmailService
    {
        public bool SendEMail (string email, string subject, string message, string filePath);
    }
}

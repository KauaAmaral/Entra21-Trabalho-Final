using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IPaymentEntityMapping _paymentEntityMapping;
        public Payment Register(PaymentRegisterViewModel registerViewModel, string pathFiles)
        {
            var path = SaveFile(registerViewModel, pathFiles);

            var payment = _paymentEntityMapping.RegisterWith(registerViewModel, path);

            _paymentRepository.Register(payment);

            return payment;
        }

        private string SaveFile(PaymentViewModel registerViewModel, string pathFiles, string? oldFile = "")
        {
            if (registerViewModel.File == null)
                return string.Empty;

            if (!string.IsNullOrEmpty(pathFiles))
                DeleteOldFile(oldFile);

            var fileInformation = new FileInfo(registerViewModel.File.FileName);
            var fileName = Guid.NewGuid() + fileInformation.Extension;

            var pathFile = Path.Combine(fileName);

            using (var stream = new FileStream(pathFile, FileMode.Create))
            {
                registerViewModel.File.CopyTo(stream);

                return fileName;
            }
        }

        private void DeleteOldFile(string oldFile)
        {
            var pathOldFile = Path.Join(oldFile);

            if (File.Exists(pathOldFile))
                File.Delete(pathOldFile);
        }
    }
}

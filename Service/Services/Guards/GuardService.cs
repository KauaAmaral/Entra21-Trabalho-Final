using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Guards;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.Services.Guards
{
    public class GuardService : IGuardService
    {
        private readonly IGuardRepository _guardRepository;
        private readonly IGuardEntityMapping _guardEntityMapping;

        public GuardService(
            GuardRepository guardRepository,
            GuardEntityMapping guardEntityMapping)
        {
            _guardRepository = guardRepository;
            _guardEntityMapping = guardEntityMapping;
        }

        public bool Delete(int id) =>
            _guardRepository.Delete(id);

        public IList<Guard> GetAll() =>
            _guardRepository.GetAll();
       

        public Guard? GetById(int id) =>
            _guardRepository.GetById(id);
       

        public Guard Register(GuardRegisterViewModel viewModel, string pathFiles)
        {
            var path = SaveFile(viewModel, pathFiles);

            var guard = _guardEntityMapping.RegisterWith(viewModel, pathFiles);

            _guardRepository.Insert(guard);

            return guard;
        }

        public bool Update(GuardUpdateViewModel viewModel, string pathFiles)
        {
            var guard = _guardRepository.GetById(viewModel.Id);

            if (guard == null)
                return false;

            var path = SaveFile(viewModel, pathFiles);

            _guardEntityMapping.UpdateWith(guard, viewModel, path);

            _guardRepository.Update(guard);

            return true;
        }

        private string SaveFile(GuardViewModel viewModel, string pathFiles, string? oldFile = "")
        {
            if (viewModel.File == null)
                return string.Empty;

            if (!string.IsNullOrEmpty(oldFile))
                DeleteOldFile(oldFile);

            var fileInformation = new FileInfo(viewModel.File.FileName);
            var fileName = Guid.NewGuid() + fileInformation.Extension;

            var pathFile = Path.Combine(fileName);

            using (var stream = new FileStream(pathFile, FileMode.Create))
            {
                viewModel.File.CopyTo(stream);

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

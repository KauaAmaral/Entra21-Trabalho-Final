using FluentValidation;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users.Validations
{
    internal class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(user => user.IdentificationId)
                .Length(6)
                .When(user => user.Hierarchy == Repository.Enums.UserHierarchy.Guarda)
                .WithMessage("O número de identificação deve ser de 6 caracteres");

        }
    }
}

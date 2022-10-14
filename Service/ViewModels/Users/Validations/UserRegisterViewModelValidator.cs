using FluentValidation;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users.Validations
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(user => user.IdentificationId)
                .NotEmpty()
                .Length(6)
                .WithName("ID de identificação")
                .WithMessage("O número de identificação deve ser de 6 caracteres")
                .When(user => user.Hierarchy == Repository.Enums.UserHierarchy.Guarda);
        }
    }
}

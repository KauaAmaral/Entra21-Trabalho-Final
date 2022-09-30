using FluentValidation;

namespace Entra21.CSharp.Area21.Service.ViewModels.Users.Validations
{
    public class UserUpdateAdministratorViewModelValidator : AbstractValidator<UserUpdateAdministratorViewModel>
    {
        public UserUpdateAdministratorViewModelValidator()
        {
            RuleFor(user => user.IdentificationId)
                .Length(6)
                .WithMessage("O número de identificação deve ser de 6 caracteres")
                .When(user => user.Hierarchy == Repository.Enums.UserHierarchy.Guarda);
        }
    }
}

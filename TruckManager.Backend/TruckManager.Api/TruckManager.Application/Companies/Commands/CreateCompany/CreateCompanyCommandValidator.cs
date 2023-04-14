using FluentValidation;

namespace TruckManager.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator() 
        {
            RuleFor(x => x.CompanyName).NotEmpty();
        }
    }
}

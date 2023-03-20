using FluentValidation;

namespace TruckManager.Application.Authentication.Queries.Login
{

    public class LoginQueryvalidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryvalidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

        }
    }
}

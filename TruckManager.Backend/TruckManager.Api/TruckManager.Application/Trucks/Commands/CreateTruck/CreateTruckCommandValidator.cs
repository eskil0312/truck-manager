using FluentValidation;

namespace TruckManager.Application.Trucks.Commands.CreateTruck
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotEmpty();
            RuleFor(x=> x.Weight).NotEmpty();
            RuleFor(x => x.RegistrationDate).NotEmpty();
            RuleFor(x => x.FuelType).NotEmpty();
            RuleFor(x => x.FuelTankSize).NotEmpty();
        }
    }
}

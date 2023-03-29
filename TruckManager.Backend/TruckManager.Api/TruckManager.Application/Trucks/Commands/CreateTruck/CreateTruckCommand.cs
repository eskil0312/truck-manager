using ErrorOr;
using MediatR;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Trucks.Commands.CreateTruck
{
    public record CreateTruckCommand(
    string RegistrationNumber,
    string FuelType,
    int FuelTankSize,
    Guid CompanyId,
    int Weight,
    DateTime RegistrationDate,
    DateTime VeichleAllowenceExperationDate) : IRequest<ErrorOr<Truck>>;
}

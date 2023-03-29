using ErrorOr;
using MediatR;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Trucks.Commands.CreateTruck
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, ErrorOr<Truck>>
    {
        private readonly ITruckRepository _truckRepository;

        public CreateTruckCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<ErrorOr<Truck>> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var truck = Truck.Create(
                registrationNumber: request.RegistrationNumber,
                fuelType: request.FuelType,
                fuelTankSize: request.FuelTankSize,
                weight: request.Weight,
                registrationDate: request.RegistrationDate,
                veichleAllowenceExperationDate: request.VeichleAllowenceExperationDate,
                companyId: CompanyId.Create(request.CompanyId));

            _truckRepository.Add(truck);

            return truck;

        }
    }
}

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
        private readonly ICompanyRespository _companyRepository;


        public CreateTruckCommandHandler(ITruckRepository truckRepository, ICompanyRespository companyRepository)
        {
            _truckRepository = truckRepository;
            _companyRepository = companyRepository;
        }

        public async Task<ErrorOr<Truck>> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetCompany(CompanyId.Create(request.CompanyId));
            if(company is null)
            {
               return Error.Validation("Company does not exist");
            }
            var truck = Truck.Create(
                registrationNumber: request.RegistrationNumber,
                fuelType: request.FuelType,
                fuelTankSize: request.FuelTankSize,
                weight: request.Weight,
                registrationDate: request.RegistrationDate,
                veichleAllowenceExperationDate: request.VeichleAllowenceExperationDate,
                companyId: CompanyId.Create(request.CompanyId));

            await _truckRepository.Add(truck);

            return truck;

        }
    }
}

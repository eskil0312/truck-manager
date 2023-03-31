using ErrorOr;
using MediatR;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Trucks.Queries.ListTrucks
{
    public class ListTrucksQueryHandler : IRequestHandler<ListTrucksQuery, ErrorOr<IEnumerable<Truck>>>
    {
        private readonly ITruckRepository _truckRepository;

        public ListTrucksQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<ErrorOr<IEnumerable<Truck>>> Handle(ListTrucksQuery request, CancellationToken cancellationToken)
        {
            var companyId = CompanyId.Create(request.CompanyId);
            var trucks = await _truckRepository.GetAllForCompany(companyId);
            
            return trucks.ToList();
        }
    }
}

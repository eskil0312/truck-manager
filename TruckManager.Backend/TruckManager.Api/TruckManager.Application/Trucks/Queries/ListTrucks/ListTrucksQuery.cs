using ErrorOr;
using MediatR;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Trucks.Queries.ListTrucks
{
    public record ListTrucksQuery(Guid CompanyId) : IRequest<ErrorOr<IEnumerable<Truck>>>;
}

using MediatR;

namespace TruckManager.Core.Features.Truck;

public record GetAllTrucksQuery(int Id): IRequest<IEnumerable<string>>;

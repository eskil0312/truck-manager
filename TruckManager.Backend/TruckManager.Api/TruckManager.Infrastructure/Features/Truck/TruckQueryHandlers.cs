using MediatR;
using TruckManager.Core.Features.Truck;

namespace TruckManager.Infrastrucure.Features.Truck;

public class TruckQueryHandlers : IRequestHandler<GetAllTrucksQuery, IEnumerable<string>>
{
    public Task<IEnumerable<string>> Handle(GetAllTrucksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

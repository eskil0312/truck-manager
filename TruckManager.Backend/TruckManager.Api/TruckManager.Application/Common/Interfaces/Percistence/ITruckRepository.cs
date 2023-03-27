using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface ITruckRepository
    {
        void Add(Truck truck);
    }
}

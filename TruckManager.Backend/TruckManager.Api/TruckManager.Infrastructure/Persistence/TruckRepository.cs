using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Infrastructure.Persistence
{
    public class TruckRepository : ITruckRepository
    {
        private static readonly List<Truck> _trucks = new();

        public void Add(Truck truck)
        {
            _trucks.Add(truck);
        }
    }
}

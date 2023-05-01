using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.TruckAggregate.Events
{
    public record TruckCreated(Truck truck) : IDomainEvent;
}

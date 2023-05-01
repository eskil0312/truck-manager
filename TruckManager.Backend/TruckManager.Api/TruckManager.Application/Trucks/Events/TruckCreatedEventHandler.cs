using MediatR;
using TruckManager.Domain.TruckAggregate.Events;

namespace TruckManager.Application.Trucks.Events
{
    public class TruckCreatedEventHandler : INotificationHandler<TruckCreated>
    {
        public Task Handle(TruckCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

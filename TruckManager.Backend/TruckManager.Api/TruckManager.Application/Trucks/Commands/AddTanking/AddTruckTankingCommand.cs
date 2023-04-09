using ErrorOr;
using MediatR;
using TruckManager.Domain.TruckAggregate.Entities;

namespace TruckManager.Application.Trucks.Commands.AddTanking
{
    public record AddTruckTankingCommand(Guid TruckId, int Amount, double Cost, string Currency) : IRequest<ErrorOr<TruckTanking>>;
    
}

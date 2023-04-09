using ErrorOr;
using MediatR;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.Common.ValueObjects;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Application.Trucks.Commands.AddTanking
{

    public class AddTruckTankingCommandHandler : IRequestHandler<AddTruckTankingCommand, ErrorOr<TruckTanking>>
    {
        private readonly ITruckRepository _truckRepository;

        public AddTruckTankingCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<ErrorOr<TruckTanking>> Handle(AddTruckTankingCommand request, CancellationToken cancellationToken)
        {
            var truckId = TruckId.Create(request.TruckId);
            var truckTanking = TruckTanking.Create(Cost.Create(request.Cost, request.Currency), request.Amount);
            await _truckRepository.AddTruckTanking(truckTanking, truckId);
            return truckTanking;
        }
    }
}

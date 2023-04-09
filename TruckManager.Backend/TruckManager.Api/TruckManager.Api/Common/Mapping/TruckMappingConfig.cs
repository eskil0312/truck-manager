using Mapster;
using TruckManager.Application.Trucks.Commands.AddTanking;
using TruckManager.Application.Trucks.Commands.CreateTruck;
using TruckManager.Contracts.Truck;
using TruckManager.Domain.TruckAggregate;
using TruckManager.Domain.TruckAggregate.Entities;

namespace TruckManager.Api.Common.Mapping
{
    public class TruckMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateTruckRequest Request, string CompanyId), CreateTruckCommand>()
                .Map(dest => dest.CompanyId, src => src.CompanyId)
                .Map(dest => dest, src => src.Request);
            config.NewConfig<Truck, TruckResponse>().Map(dest => dest.Id, src => src.Id.Value);
            config.NewConfig<(AddTruckTankingRequest Request, string CompanyId, string TruckId), AddTruckTankingCommand>()
                .Map(dest => dest.TruckId, src => src.TruckId)
                .Map(dest => dest, src => src.Request);
            config.NewConfig<TruckTanking, TruckTankingResponse>()
                .Map(dest => dest.TruckId, src => src.Id.Value)
                .Map(dest => dest.Amount, src => src.Quantiy).Map(dest => dest.Currency, src => src.Cost.Currency)
                .Map(dest =>dest.Cost, src => src.Cost.Amount);

        }
    }
}

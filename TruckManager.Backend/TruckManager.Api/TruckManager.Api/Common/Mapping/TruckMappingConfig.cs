﻿using Mapster;
using TruckManager.Application.Trucks.Commands.CreateTruck;
using TruckManager.Contracts.Truck;
using TruckManager.Domain.TruckAggregate;

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

        }
    }
}

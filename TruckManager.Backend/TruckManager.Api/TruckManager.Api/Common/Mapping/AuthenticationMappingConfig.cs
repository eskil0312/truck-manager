using Mapster;
using TruckManager.Application.Authentication.Common;
using TruckManager.Contracts.Authentication;

namespace TruckManager.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Application.Trucks.Commands.AddTanking
{
    public record AddTankingCommand(Guid TruckId, int Amount, string Currency) : IRequest;
    
}

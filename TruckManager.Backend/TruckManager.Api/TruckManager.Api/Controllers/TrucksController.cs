using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Trucks.Commands.AddTanking;
using TruckManager.Application.Trucks.Commands.CreateTruck;
using TruckManager.Application.Trucks.Queries.ListTrucks;
using TruckManager.Contracts.Truck;

namespace TruckManager.Api.Controllers;

[Route("companies/{companyId}/trucks")]
public class TrucksController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TrucksController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTruck(CreateTruckRequest request, string companyId)
    {
        var command = _mapper.Map<CreateTruckCommand>((request, companyId));
        var createTruckResult = await _mediator.Send(command);
        return createTruckResult.Match(
            truck => Ok(_mapper.Map<TruckResponse>(truck)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListTrucks(Guid companyId)
    {
        var createTruckResult = await _mediator.Send(new ListTrucksQuery(companyId));
        var first = createTruckResult.Value.First().Id.Value.ToString();
        return createTruckResult.Match(
            trucks => Ok(trucks.Select(t => _mapper.Map<TruckResponse>(t))),
            Problem);
    }

    [HttpPost("{truckId}/tanking")]
    public async Task<IActionResult> AddTanking(AddTruckTankingRequest request, string companyId, string truckId)
    {
        var command = _mapper.Map<AddTruckTankingCommand>((request, companyId, truckId));
        var addTruckTankingResponse = await _mediator.Send(command);
        return addTruckTankingResponse.Match(
            tanking => Ok(_mapper.Map<TruckTankingResponse>(tanking)),
            Problem);
    }
}

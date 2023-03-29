﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Trucks.Commands.CreateTruck;
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
    //[HttpGet]
    //public async Task<IActionResult> ListTrucks()
    //{
    //    var command = _mapper.Map<CreateTruckCommand>(request);
    //    var createTruckResult = await _mediator.Send(command);
    //    return createTruckResult.Match(
    //        truck => Ok(_mapper.Map<TruckResponse>(truck)),
    //        Problem);
    //}
}

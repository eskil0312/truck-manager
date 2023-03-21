using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Api.Dtos;
using TruckManager.Core.Features.Truck;

namespace TruckManager.Api.Controllers;

[Route("[controller]")]
public class TrucksController : ApiController
{
    private readonly IMediator _mediator;

    public TrucksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult ListTrucks()
    {
        return Ok(Array.Empty<string>());
    }

    //[HttpGet]
    //public async Task<IEnumerable<string>> GetTrucks()
    //{
    //    var query = new GetAllTrucksQuery(2);
    //    return await _mediator.Send(query);
    //}
     
    [HttpGet("{id:length(24)}", Name = "GetTruck")]
    public Task<TruckResponse> GetTruckById(string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<TruckResponse> Create(CreateTruckRequest truck)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
        throw new NotImplementedException();
    }
}

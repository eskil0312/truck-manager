using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Companies.Commands.CreateCompany;
using TruckManager.Contracts.Company;

namespace TruckManager.Api.Controllers
{
    [Route("companies")]
    public class CompanyController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompanyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            var command = _mapper.Map<CreateCompanyCommand>(request);
            var createTruckResult = await _mediator.Send(command);
            return createTruckResult.Match(
                truck => Ok(_mapper.Map<CompanyResponse>(truck)),
                Problem);
        }
    }
}

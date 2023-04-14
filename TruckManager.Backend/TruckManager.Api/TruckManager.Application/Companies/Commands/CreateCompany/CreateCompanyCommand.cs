using ErrorOr;
using MediatR;
using TruckManager.Domain.CompanyAggregate;

namespace TruckManager.Application.Companies.Commands.CreateCompany
{
    public record CreateCompanyCommand(string CompanyName) :  IRequest<ErrorOr<Company>>;
}

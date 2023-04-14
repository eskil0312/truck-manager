using ErrorOr;
using MediatR;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.CompanyAggregate;

namespace TruckManager.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ErrorOr<Company>>
    {

        public readonly ICompanyRespository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRespository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ErrorOr<Company>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = Company.Create(request.CompanyName);
            await _companyRepository.Add(company);
            return company;
        }
    }
}

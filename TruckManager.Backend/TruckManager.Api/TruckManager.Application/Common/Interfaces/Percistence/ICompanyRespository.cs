using TruckManager.Domain.CompanyAggregate;
using TruckManager.Domain.CompanyAggregate.ValueObjects;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface ICompanyRespository
    {
        Task Add(Company company);
        Task<Company?> GetCompany(CompanyId company);

    }
}

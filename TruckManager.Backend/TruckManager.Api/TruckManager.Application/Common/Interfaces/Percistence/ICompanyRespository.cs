using TruckManager.Domain.CompanyAggregate;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface ICompanyRespository
    {
        Task Add(Company company);
    }
}

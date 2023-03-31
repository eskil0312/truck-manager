using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface ITruckRepository
    {
        Task Add(Truck truck);

        Task<IEnumerable<Truck>> GetAllForCompany(CompanyId companyId);
    }
}

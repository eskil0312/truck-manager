using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface ITruckRepository
    {
        Task Add(Truck truck);

        Task<IEnumerable<Truck>> GetAllForCompany(CompanyId companyId);

        Task AddTruckTanking(TruckTanking tanking, TruckId truckId);
    }
}

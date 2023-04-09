using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Infrastructure.Persistence.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckManagerDbContext _dbContext;

        public TruckRepository(TruckManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Truck truck)
        {
            await _dbContext.AddAsync(truck);

            await _dbContext.SaveChangesAsync();

        }

        public async Task AddTruckTanking(TruckTanking tanking, TruckId truckId)
        {
            var truck = await _dbContext.Set<Truck>().Where(truck => truck.Id == truckId).FirstOrDefaultAsync();
            if(truck is null)
            {
                return;
            }
            truck.AddTruckTanking(tanking);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Truck>> GetAllForCompany(CompanyId companyId)
        {
            return await _dbContext.Set<Truck>().Where(t => t.CompanyId == companyId).ToListAsync();
        }

    }
}

using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Infrastructure.Persistence.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckManagerDbContext _dbContext;

        public TruckRepository(TruckManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Truck truck)
        {
            _dbContext.Add(truck);

            _dbContext.SaveChanges();

        }
    }
}

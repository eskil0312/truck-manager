using Microsoft.EntityFrameworkCore;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.CompanyAggregate;
using TruckManager.Domain.CompanyAggregate.ValueObjects;

namespace TruckManager.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRespository
    {
        private readonly TruckManagerDbContext _dbContext;

        public CompanyRepository(TruckManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Company company)
        {
            await _dbContext.AddAsync(company);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Company?> GetCompany(CompanyId companyId)
        {
            return await _dbContext.Set<Company>().Where(c => c.Id == companyId).FirstOrDefaultAsync();
        }
    }
}

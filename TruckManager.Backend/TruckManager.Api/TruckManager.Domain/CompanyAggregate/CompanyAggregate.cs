using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.UserAggregate.ValueObjects;

namespace TruckManager.Domain.CompanyAggregate
{
    public class Company : AggregateRoot<CompanyId>
    {
        private Company(CompanyId companyId, string companyName, DateTime updateDateTime, DateTime createdDateTime) : base(companyId)
        {
            CompanyName = companyName;
            UpdateDateTime = updateDateTime;
            CreatedDateTime = createdDateTime;
        }

        public string CompanyName { get; private set; }

        public DateTime UpdateDateTime { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        private readonly List<UserId> _userIds = new();

        public IReadOnlyList<UserId> UserIds => _userIds.AsReadOnly();

        public static Company Create(string companyName)
        {
            return new(CompanyId.CreateUnique(), companyName, DateTime.Now, DateTime.Now);
        }
    }
}

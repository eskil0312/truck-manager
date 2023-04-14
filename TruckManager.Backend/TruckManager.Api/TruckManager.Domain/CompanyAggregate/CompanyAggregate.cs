using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate.ValueObjects;
using TruckManager.Domain.UserAggregate.ValueObjects;

namespace TruckManager.Domain.CompanyAggregate
{
    public class Company : AggregateRoot<CompanyId, Guid>
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

        private readonly List<TruckId> _truckIds = new();

        public IReadOnlyList<TruckId> TruckIds => _truckIds.AsReadOnly();

        public static Company Create(string companyName)
        {
            return new(CompanyId.CreateUnique(), companyName, DateTime.Now, DateTime.Now);
        }

        #pragma warning disable CS8618
        private Company()
        {
        }
        #pragma warning restore CS8618
    }
}

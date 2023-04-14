using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.CompanyAggregate.ValueObjects
{
    public sealed class CompanyId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public CompanyId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static CompanyId Create(Guid value)
        {
            return new CompanyId(value);
        }


        public static CompanyId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

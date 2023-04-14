using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static UserId Create(Guid value)
        {
            // Todo: Enforce invariants
            return new UserId(value);
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

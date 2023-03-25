using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

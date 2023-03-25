using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.TruckAggregate.ValueObjects
{
    public sealed class TruckId : ValueObject
    {
        public Guid Value { get; }

        public TruckId(Guid value) 
        { 
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static TruckId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

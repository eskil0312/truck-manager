using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.TruckAggregate.ValueObjects
{
    public sealed class TruckId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public TruckId(Guid value) 
        { 
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static TruckId Create(Guid value)
        {
            // Todo: Enforce invariants
            return new TruckId(value);
        }

        public static TruckId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

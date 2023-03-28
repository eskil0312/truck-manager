using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.TruckAggregate.ValueObjects
{
    public sealed class TruckTankingId : ValueObject
    {
        public Guid Value { get; }

        public TruckTankingId(Guid value) 
        { 
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
        public static TruckTankingId Create(Guid value)
        {
            // Todo: Enforce invariants
            return new TruckTankingId(value);
        }

        public static TruckTankingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

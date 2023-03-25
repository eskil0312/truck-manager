using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.TruckAggregate.ValueObjects
{
    public sealed class TruckInicdentId : ValueObject
    {
        public Guid Value { get; }

        public TruckInicdentId(Guid value) 
        { 
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }

        public static TruckInicdentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}

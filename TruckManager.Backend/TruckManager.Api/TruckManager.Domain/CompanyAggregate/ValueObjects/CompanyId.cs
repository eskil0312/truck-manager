using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.CompanyAggregate.ValueObjects
{
    public sealed class CompanyId : ValueObject
    {
        public Guid Value { get; }

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

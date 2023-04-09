
using TruckManager.Domain.Common.Models;

namespace TruckManager.Domain.Common.ValueObjects
{
    public sealed class Cost : ValueObject
    {
        public double Amount { get; private set; }
        public string Currency { get; private set; }

        private Cost(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Amount;
            yield return Currency;
        }

        public static Cost Create(double amount, string currency)
        {
            // Todo: Enforce invariants
            return new Cost(amount, currency);
        }

    }
}

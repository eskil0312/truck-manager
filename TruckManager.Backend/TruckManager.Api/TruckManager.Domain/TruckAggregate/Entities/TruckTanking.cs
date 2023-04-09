using TruckManager.Domain.Common.Models;
using TruckManager.Domain.Common.ValueObjects;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate.Entities
{
    public sealed class TruckTanking : Entity<TruckTankingId>
    {
        private TruckTanking(TruckTankingId truckTankingId, Cost cost, int quantity, DateTime date)
            : base(truckTankingId)
        {
            Cost = cost;
            Quantiy = quantity;
            Date = date;
        }
        public Cost Cost { get; private set; }
        public int Quantiy { get; private set; }
        public DateTime Date { get; private set; }

        public static TruckTanking Create(Cost cost, int quantity)
        {
            return new(TruckTankingId.CreateUnique(), cost, quantity, DateTime.Now);
        }

#pragma warning disable CS8618
        private TruckTanking()
        {
        }
#pragma warning restore CS8618
    }
}

using TruckManager.Domain.Common.Models;
using TruckManager.Domain.Common.ValueObjects;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate.Entities
{
    public sealed class TruckTanking : Entity<TruckTankingId>
    {
        private TruckTanking(TruckTankingId truckIncidentId, Cost cost, string quantity, DateTime date)
            : base(truckIncidentId)
        {
            Cost = cost;
            Quantiy = quantity;
            Date = date;
        }
        public Cost Cost { get; private set; }
        public string Quantiy { get; private set; }
        public DateTime Date { get; private set; }

        public static TruckTanking Create(Cost cost, string quantity, DateTime Date)
        {
            return new(TruckTankingId.CreateUnique(), cost, quantity, Date);
        }

#pragma warning disable CS8618
        private TruckTanking()
        {
        }
#pragma warning restore CS8618
    }
}

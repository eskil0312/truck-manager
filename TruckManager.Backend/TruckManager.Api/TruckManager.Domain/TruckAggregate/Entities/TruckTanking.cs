using TruckManager.Domain.Common.Models;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate.Entities
{
    public sealed class TruckTanking : Entity<TruckTankingId>
    {
        private TruckTanking(TruckTankingId truckIncidentId, string cost, string quantity, DateTime date)
            : base(truckIncidentId)
        {
            Cost = cost;
            Quantiy = quantity;
            Date = date;
        }
        public string Cost { get; }
        public string Quantiy { get; }
        public DateTime Date { get; }

        public static TruckTanking Create(string cost, string quantity, DateTime Date)
        {
            return new(TruckTankingId.CreateUnique(), cost, quantity, Date);
        }

    }
}

using TruckManager.Domain.Common.Models;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate.Entities
{
    public sealed class TruckIncident : Entity<TruckInicdentId>
    {
        private TruckIncident(TruckInicdentId truckIncidentId, string description, string title, DateTime date) 
            : base(truckIncidentId)
        {
            Description = description;
            Title = title;
            Date = date;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public static TruckIncident Create(string title, string description, DateTime Date)
        {
            return new(TruckInicdentId.CreateUnique(), title, description, Date);
        }

#pragma warning disable CS8618
        private TruckIncident()
        {
        }
#pragma warning restore CS8618

    }
}

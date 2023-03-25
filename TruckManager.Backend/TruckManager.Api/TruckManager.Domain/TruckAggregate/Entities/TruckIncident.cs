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
        public string Title { get; }
        public string Description { get; }
        public DateTime Date { get; }

        public static TruckIncident Create(string title, string description, DateTime Date)
        {
            return new(TruckInicdentId.CreateUnique(), title, description, Date);
        }

    }
}

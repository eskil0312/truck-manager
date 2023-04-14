using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate
{
    public sealed class Truck : AggregateRoot<TruckId, Guid>
    {
        private Truck(
            TruckId truckId,
            string registrationNumber,
            string fuelType,
            int fuelTankSize,
            int weight,
            DateTime registrationDate,
            DateTime veichleAllowenceExperationDate,
            CompanyId companyId,
            DateTime updateDateTime,
            DateTime createdDateTime)
           : base(truckId)
        {
            RegistrationNumber = registrationNumber;
            FuelType = fuelType;
            FuelTankSize = fuelTankSize;
            Weight = weight;
            RegistrationDate = registrationDate;
            VeichleAllowenceExperationDate = veichleAllowenceExperationDate;
            CompanyId = companyId;
            UpdateDateTime = updateDateTime;
            CreatedDateTime = createdDateTime;
        }

        public string RegistrationNumber { get; private set; }

        public string FuelType { get; private set; }

        public int FuelTankSize { get; private set; }

        public int Weight { get; private set; }

        public DateTime RegistrationDate { get; private set; }

        public DateTime VeichleAllowenceExperationDate { get; private set; }

        public CompanyId CompanyId { get; private set; }

        private readonly List<TruckIncident> _incidents = new();

        public IReadOnlyList<TruckIncident> Incidents => _incidents.AsReadOnly();

        public readonly List<TruckTanking> _tankings = new();

        public IReadOnlyList<TruckTanking> Tankings => _tankings.AsReadOnly();

        public DateTime UpdateDateTime { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        
        public static Truck Create(string registrationNumber,
            string fuelType,
            int fuelTankSize,
            int weight,
            DateTime registrationDate,
            DateTime veichleAllowenceExperationDate,
            CompanyId companyId)
        {
            return new(
                TruckId.CreateUnique(),
                registrationNumber,
                fuelType,
                fuelTankSize,
                weight,
                registrationDate,
                veichleAllowenceExperationDate,
                companyId, DateTime.Now, DateTime.Now);
        }

        public void AddTruckTanking(TruckTanking truckTanking)
        {
           _tankings.Add(truckTanking);
        }

        #pragma warning disable CS8618
        private Truck( )
        {
        }
        #pragma warning restore CS8618


    }
}

using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Domain.TruckAggregate
{
    public sealed class Truck : AggregateRoot<TruckId>
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

        public string RegistrationNumber { get; }

        public string FuelType { get; }

        public int FuelTankSize { get; }
        public int Weight { get; }

        public DateTime RegistrationDate { get; }

        public DateTime VeichleAllowenceExperationDate { get; }

        public CompanyId CompanyId { get; }

        private readonly List<TruckIncident> _incidents = new();

        public IReadOnlyList<TruckIncident> Incidents => _incidents.AsReadOnly();

        public List<TruckTanking> _tankings = new();

        public IReadOnlyList<TruckTanking> Tankings => _tankings.AsReadOnly();

        public DateTime UpdateDateTime { get; }

        public DateTime CreatedDateTime { get; }


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


    }
}

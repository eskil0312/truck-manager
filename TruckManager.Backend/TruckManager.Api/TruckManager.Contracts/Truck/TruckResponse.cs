namespace TruckManager.Contracts.Truck
{
    public record TruckResponse(Guid Id,
            string RegistrationNumber,
            string FuelType,
            int FuelTankSize,
            DateTime RegistrationDate,
            DateTime VeichleAllowenceExperationDate,
            int Weight,
            List<string> Incidents,
            List<string> Tankings,
            DateTime UpdateDateTime,
            DateTime CreatedDateTime);
}

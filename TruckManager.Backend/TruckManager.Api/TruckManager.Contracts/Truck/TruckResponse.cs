namespace TruckManager.Contracts.Truck
{
    public record TruckResponse(string Id,
            string RegistrationNumber,
            string FuelType,
            int FuelTankSize,
            DateTime RegistrationDate,
            DateTime VeichleAllowenceExperationDate,
            int Weight,
            List<string> Incidents,
            List<TruckTankingResponse> Tankings,
            DateTime UpdateDateTime,
            DateTime CreatedDateTime);
}

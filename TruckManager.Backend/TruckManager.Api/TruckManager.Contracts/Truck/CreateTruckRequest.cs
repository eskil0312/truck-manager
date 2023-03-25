namespace TruckManager.Contracts.Truck
{
    public record CreateTruckRequest(string RegistrationNumber, string FuelType, int FuelTankSize, DateTime RegistrationDate, string VeichleAllowenceExperationDate);
}

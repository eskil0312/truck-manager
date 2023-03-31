namespace TruckManager.Contracts.Truck
{
    public record CreateTruckRequest(
        string RegistrationNumber,
        string FuelType,
        int FuelTankSize,
        int Weight,
        DateTime RegistrationDate,
        DateTime VeichleAllowenceExperationDate);
}

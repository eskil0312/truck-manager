namespace TruckManager.Contracts.Truck
{
    public record CreateTruckRequest(
        string RegistrationNumber,
        string FuelType,
        int FuelTankSize,
        int Weight,
        string CompanyId,
        DateTime RegistrationDate,
        DateTime VeichleAllowenceExperationDate);
}

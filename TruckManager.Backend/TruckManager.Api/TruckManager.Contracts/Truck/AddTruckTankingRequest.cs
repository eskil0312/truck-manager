namespace TruckManager.Contracts.Truck
{
    public record AddTruckTankingRequest(Guid TruckId, int Amount, double Cost, string Currency);
}

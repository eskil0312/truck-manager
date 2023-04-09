namespace TruckManager.Contracts.Truck
{
    public record TruckTankingResponse(Guid TruckId, int Amount, double Cost, string Currency, DateTime Date);
}

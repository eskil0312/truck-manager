namespace TruckManager.Contracts.Truck
{
    public record TruckTankingResponse(string TruckId, int Amount, double Cost, string Currency, DateTime Date);
}

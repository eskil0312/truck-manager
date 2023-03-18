namespace TruckManager.Api.Dtos;

public class TruckResponse
{
    public string Id { get; set; } = null!;

    public string RegNr { get; set; } = null!;

    public int Weight { get; set; }

    public int TotDistance { get; set; }

    public decimal AvgLiterPerMil { get; set; }

    public decimal AvgCostNokPerLiter { get; set; }

    public decimal AvgCostPerMil { get; set; }

    public string FuelType { get; set; } = null!;
}

namespace TruckManager.Api.Dtos;

public class CreateTruckRequest
{
    public string RegNr { get; set; } = null!;

    public int Weight { get; set; }

    public int? TotDistance { get; set; }
}

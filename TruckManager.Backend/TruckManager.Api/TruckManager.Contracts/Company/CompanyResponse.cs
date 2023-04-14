namespace TruckManager.Contracts.Company
{
    public record CompanyResponse(
        Guid Id,
        string Name,
        DateTime RegistrationDate,
        DateTime VeichleAllowenceExperationDate);
}

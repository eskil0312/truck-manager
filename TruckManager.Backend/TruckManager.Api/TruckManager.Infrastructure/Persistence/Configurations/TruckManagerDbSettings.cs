namespace TruckManager.Infrastructure.Persistence.Configurations
{
    public class TruckManagerDbSettings
    {
        public const string SectionName = "TruckManagerDb";
        public string ConnectionString { get; set; } = null!;
    }
}

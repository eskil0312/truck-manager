using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TruckManager.API.Models
{
    public class Trucks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("regNr")]
        public string RegNr { get; set; }

        [BsonElement("weight")]
        public int Weight { get; set; }

        [BsonElement("totDistance")]
        public int TotDistance { get; set; }

        [BsonElement("avgLiterPerMil")]
        public decimal AvgLiterPerMil { get; set; }

        [BsonElement("avgCostNokPerLiter")]
        public decimal AvgCostNokPerLiter { get; set; }

        [BsonElement("avgCostPerMil")]
        public decimal AvgCostPerMil { get; set; }

        [BsonElement("fuelType")]
        public string FuelType { get; set; }

        [BsonElement("tankings")]
        public List<Tanking> Tankings { get; set; }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TruckManager.API.Models
{
    public class Tanking
    {
        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("distance")]
        public int Distance { get; set; }

        [BsonElement("cost")]
        public decimal Cost { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

        [BsonElement("quantityLiter")]
        public decimal QuantityLiter { get; set; }

    }
}
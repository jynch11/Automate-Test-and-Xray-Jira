using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Ticketing.API.Entities
{
    public class TicketEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("accountNumber")]
        public int AccountNumber { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; } = null!;

        [JsonPropertyName("meterNumber")]
        public string? MeterNumber { get; set; } = null!;

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("contactNumber")]
        public string? ContactNumber { get; set; }

        [JsonPropertyName("otherdetails")]
        public string? OtherDetails { get; set; }

        [JsonPropertyName("orNumber")]
        public string? ORNumber { get; set; }

        [JsonPropertyName("photos")]
        public List<string>? Photos { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
   
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();
    }
}

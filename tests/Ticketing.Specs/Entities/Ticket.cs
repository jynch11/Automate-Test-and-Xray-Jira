using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ticketing.Specs.Entities
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int AccountNumber { get; set; }
        public string AccountName { get; set; } = null!;
        public string? MeterNumber { get; set; } = null!;
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? OtherDetails { get; set; }
        public string? ORNumber { get; set; }
        public List<string>? Photos { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();
    }
}

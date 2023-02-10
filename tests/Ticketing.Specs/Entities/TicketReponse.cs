using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ticketing.Specs.Entities
{
    public class TicketResponse
    {
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
    }
}

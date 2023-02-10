using MongoDB.Driver;
using Ticketing.API.Entities;

namespace Ticketing.API.Data
{
    public class TicketContext : ITicketContext
    {
        public TicketContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Tickets = database.GetCollection<TicketEntity>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            TicketContextSeed.SeedData(Tickets);
            
        }
        public IMongoCollection<TicketEntity> Tickets { get; }
    }
}
 
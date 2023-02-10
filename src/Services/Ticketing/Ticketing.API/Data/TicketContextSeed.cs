using MongoDB.Driver;
using Ticketing.API.Entities;

namespace Ticketing.API.Data
{
    public class TicketContextSeed
    {
        public static void SeedData(IMongoCollection<TicketEntity> ticketCollection)
        {
            bool existTicket = ticketCollection.Find(t => true).Any();
            if (!existTicket)
            {
                ticketCollection.InsertManyAsync(GetPreconfigurationTickets());
            }
        }

        private static IEnumerable<TicketEntity> GetPreconfigurationTickets()
        {

            return new List<TicketEntity>()
            {
                new TicketEntity()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Type = "Complaints",
                    Name = "No Water",
                    AccountNumber = 12345678,
                    AccountName = "Jm Albasin",
                    MeterNumber = "87654321",
                    Address = "C.M Recto Ext.",
                    ContactNumber = "09676181217",
                    OtherDetails = "Just a test",
                    ORNumber = "0987654321",
                    Photos = new()
                    {
                        "https://wallpapercave.com/wp/wp10279812.jpg"
                    },
                    Status = "For Approval"

                },
                new TicketEntity()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Type = "Complaints",
                    Name = "Water Leak",
                    AccountNumber = 12345678,
                    AccountName = "Jm Albasin",
                    MeterNumber = "87654321",
                    Address = "C.M Recto Ext.",
                    ContactNumber = "09676181217",
                    OtherDetails = "Just a test",
                    ORNumber = "0987654321",
                    Photos = new()
                    {
                        "https://imageio.forbes.com/blogs-images/natalieparletta/files/2019/06/AdobeStock_234736184-by-manola72-1200x800.jpg?format=jpg&width=960"
                    },
                    Status = "For Approval"

                }


            };
        }
    }
}

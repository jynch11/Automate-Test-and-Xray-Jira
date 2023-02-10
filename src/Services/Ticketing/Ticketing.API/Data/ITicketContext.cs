using MongoDB.Driver;
using Ticketing.API.Entities;

namespace Ticketing.API.Data
{
    public interface ITicketContext
    {
        IMongoCollection<TicketEntity> Tickets { get; }
    }
}

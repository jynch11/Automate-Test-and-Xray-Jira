using Ticketing.API.Entities;

namespace Ticketing.API.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<TicketEntity>> GetTickets();
        Task<TicketEntity> GetTicket(string id);
        Task<IEnumerable<TicketEntity>> GetTicketByName(string name);
        Task CreateTicket (TicketEntity ticket);
        Task<bool> UpdateTicket (TicketEntity ticket);



    }
}

using MongoDB.Driver;
using Ticketing.API.Data;
using Ticketing.API.Entities;

namespace Ticketing.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ITicketContext _context;

        public TicketRepository(ITicketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateTicket(TicketEntity ticket)
        {
            await _context.Tickets.InsertOneAsync(ticket);
        }


        public async Task<IEnumerable<TicketEntity>> GetTicketByName(string name)
        {
            FilterDefinition<TicketEntity> filter = Builders<TicketEntity>.Filter.Eq(t => t.Name, name);

            return await _context
                     .Tickets
                     .Find(filter)
                     .ToListAsync();
        }

        public async Task<TicketEntity> GetTicket(string id)
        {
            return await _context
                    .Tickets
                    .Find(t => t.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetTickets()
        {
            return await _context
                    .Tickets
                    .Find(t => true)
                    .ToListAsync();
        }

        public async Task <bool> UpdateTicket (TicketEntity ticket)
        {
            var updateResult = await _context
                                   .Tickets
                                   .ReplaceOneAsync (filter: g => g.Id == ticket.Id, replacement: ticket);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}

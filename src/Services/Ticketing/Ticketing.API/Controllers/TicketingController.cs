using System.Net;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Entities;
using Ticketing.API.Repositories;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketingController : ControllerBase
    {
        private readonly ITicketRepository _repository;
        private readonly ILogger<TicketingController> _logger;

        public TicketingController(ITicketRepository repository, ILogger<TicketingController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketEntity>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult <IEnumerable<TicketEntity>>> GetTickets()
        {
            var tickets = await _repository.GetTickets();
            return Ok(tickets);
        }

        [HttpGet("{id:length(24)}", Name = "GetTicket")]
        [ProducesResponseType ((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TicketEntity), (int) HttpStatusCode.OK)]

        public async Task<ActionResult<TicketEntity>> GetTicketById(string id)
        {
            var ticket = await _repository.GetTicket(id);
            if (ticket == null)
            {
                _logger.LogError($"Ticket with id: {id}, not found");
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketEntity), (int) HttpStatusCode.OK)]

        public async Task<ActionResult<TicketEntity>> CreateTicket([FromBody] TicketEntity ticket)
        {
            await _repository.CreateTicket(ticket);
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }

        [HttpPatch]
        [ProducesResponseType(typeof(TicketEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketEntity ticket)
        {
            return Ok(await _repository.UpdateTicket(ticket));
        }

    }
}

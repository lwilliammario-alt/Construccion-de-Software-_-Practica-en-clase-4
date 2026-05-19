using Microsoft.AspNetCore.Mvc;
using ConstruSoftTicket.Application.DTOs;
using ConstruSoftTicket.Application.Services;
using ConstruSoftTicket.Application.Interfaces;

namespace ConstruSoftTicket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ticketService.CreateTicketAsync(dto);

            return Ok(new
            {
                message = "Ticket registrado correctamente"
            });
        }
    }
}
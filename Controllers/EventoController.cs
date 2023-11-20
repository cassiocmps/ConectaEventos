using Microsoft.AspNetCore.Mvc;
using ConectaEventos.Models;
using ConectaEventos.Services;

namespace ConectaEventos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventoService _eventoService;

        public EventosController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public IActionResult GetAllEventos()
        {
            var eventos = _eventoService.GetAllEventos();

            if (eventos != null && eventos.Count > 0)
            {
                return Ok(eventos);
            }

            return NotFound("No Eventos found.");
        }

        [HttpGet("{id}")]
        public IActionResult GetEventoById(int id)
        {
            var evento = _eventoService.GetEventoById(id);

            if (evento != null)
            {
                return Ok(evento);
            }

            // Return a 404 Not Found response if the Evento is not found
            return NotFound($"Evento with ID {id} not found");
        }

        [HttpGet("client/{clientId}")]
        public IActionResult GetEventosByClientId(int clientId)
        {
            var eventos = _eventoService.GetEventosByClientId(clientId);

            if (eventos != null && eventos.Count > 0)
            {
                return Ok(eventos);
            }

            return NotFound($"No Eventos found for Client with ID {clientId}");
        }

        [HttpPost]
        public IActionResult AddEvento([FromBody] Evento evento)
        {
            try
            {
                _eventoService.AddEvento(evento);
                return CreatedAtAction(nameof(GetEventoById), new { id = evento.Id }, evento);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return BadRequest($"Error adding Evento: {ex.Message}");
            }
        }
    }

}

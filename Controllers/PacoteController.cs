using Microsoft.AspNetCore.Mvc;
using ConectaEventos.Services;

[Route("api/[controller]")]
[ApiController]
public class PacotesController : ControllerBase
{
    private readonly PacoteService _pacoteService;

    public PacotesController(PacoteService pacoteService)
    {
        _pacoteService = pacoteService;
    }

    [HttpGet]
    public IActionResult GetAllPacotes()
    {
        var pacotes = _pacoteService.GetAllPacotes();

        if (pacotes != null && pacotes.Count > 0)
        {
            return Ok(pacotes);
        }

        return NotFound("No Pacotes found.");
    }

    [HttpGet("{id}")]
    public IActionResult GetPacoteById(int id)
    {
        var pacote = _pacoteService.GetPacoteById(id);

        if (pacote != null)
        {
            return Ok(pacote);
        }

        return NotFound($"Pacote with ID {id} not found");
    }
}

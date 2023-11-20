using Microsoft.AspNetCore.Mvc;
using ConectaEventos.Models;
using ConectaEventos.Services;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionariosController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    public IActionResult GetAllFuncionarios()
    {
        var funcionarios = _funcionarioService.GetAllFuncionarios();

        if (funcionarios != null && funcionarios.Count > 0)
        {
            return Ok(funcionarios);
        }

        return NotFound("No Funcionarios found.");
    }

    [HttpGet("{id}")]
    public IActionResult GetFuncionarioById(int id)
    {
        var funcionario = _funcionarioService.GetFuncionarioById(id);

        if (funcionario != null)
        {
            return Ok(funcionario);
        }

        // Return a 404 Not Found response if the Funcionario is not found
        return NotFound($"Funcionario with ID {id} not found");
    }

    [HttpPost]
    public IActionResult AddFuncionario([FromBody] Funcionario funcionario)
    {
        try
        {
            _funcionarioService.AddFuncionario(funcionario);
            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
        }
        catch (Exception ex)
        {
            // Handle exceptions and return an appropriate error response
            return BadRequest($"Error adding Funcionario: {ex.Message}");
        }
    }
}

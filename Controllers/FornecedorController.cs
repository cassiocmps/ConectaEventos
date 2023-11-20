using ConectaEventos.Models;
using ConectaEventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConectaEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedorController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        public IActionResult PostFornecedor([FromBody] Fornecedor fornecedor)
        {
            try
            {
                _fornecedorService.PostFornecedor(fornecedor);
                return CreatedAtAction(nameof(GetFornecedorById), new { id = fornecedor.Id }, fornecedor);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return BadRequest($"Error creating Fornecedor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFornecedorById(int id)
        {
            var fornecedor = _fornecedorService.GetFornecedorById(id);

            if (fornecedor != null)
            {
                return Ok(fornecedor);
            }

            // Return a 404 Not Found response if the Fornecedor is not found
            return NotFound($"Fornecedor with ID {id} not found");
        }
    }
}

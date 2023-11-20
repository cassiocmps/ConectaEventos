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
        public IActionResult AdicionarFornecedor([FromBody] Fornecedor fornecedor)
        {
            try
            {
                _fornecedorService.AdicionarFornecedor(fornecedor);
                return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating Fornecedor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFornecedor(int id)
        {
            var fornecedor = _fornecedorService.GetFornecedor(id);

            if (fornecedor != null)
                return Ok(fornecedor);

            return NotFound($"Fornecedor with ID {id} not found");
        }

        [HttpPost("{id}/produtos")]
        public IActionResult AdicionarProduto(int id, [FromBody] Produto produto)
        {
            try
            {
                _fornecedorService.AdicionarProduto(id, produto);
                return CreatedAtAction(nameof(GetFornecedor), new { id }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding Produto to Fornecedor: {ex.Message}");
            }
        }

        [HttpPost("{id}/pacotes")]
        public IActionResult AdicionarPacote(int id, [FromBody] Pacote pacote)
        {
            try
            {
                _fornecedorService.AdicionarPacote(id, pacote);
                return CreatedAtAction(nameof(GetFornecedor), new { id }, pacote);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding Pacote to Fornecedor: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ConectaEventos.Services;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public IActionResult GetAllProdutos()
    {
        var produtos = _produtoService.GetAllProdutos();

        if (produtos != null && produtos.Count > 0)
        {
            return Ok(produtos);
        }

        return NotFound("No Produtos found.");
    }
}

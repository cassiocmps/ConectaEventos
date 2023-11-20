using ConectaEventos.Data;
using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{
    public class ProdutoService
    {
        private readonly ConectaEventosContext _context;

        public ProdutoService(ConectaEventosContext context)
        {
            _context = context;
        }

        public List<Produto> GetAllProdutos()
        {
            return _context.Produtos
                .AsNoTracking()
                .ToList();
        }
    }
}

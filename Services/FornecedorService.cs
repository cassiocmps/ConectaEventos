using ConectaEventos.Data;
using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{
    public class FornecedorService
    {
        private readonly ConectaEventosContext _context;

        public FornecedorService(ConectaEventosContext context)
        {
            _context = context;
        }

        public void PostFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new ArgumentNullException(nameof(fornecedor));

            _context.Fornecedores.Add(fornecedor);

            _context.SaveChanges();
        }

        public Fornecedor? GetFornecedorById(int fornecedorId)
        {
            return _context.Fornecedores
                .AsNoTracking()
                //.Include(f => f.Produtos)
                .Where(f => f.Id == fornecedorId)
                .FirstOrDefault();
        }

    }
}

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

        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new ArgumentNullException(nameof(fornecedor));

            _context.Fornecedores.Add(fornecedor);

            _context.SaveChanges();
        }

        public Fornecedor? GetFornecedor(int fornecedorId)
        {
            return _context.Fornecedores
                .AsNoTracking()
                .Include(f => f.Produtos)
                //.Include(f => f.Produtos)
                .Where(f => f.Id == fornecedorId)
                .FirstOrDefault();
        }

        public void AdicionarProduto(int fornecedorId, Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            var fornecedor = _context.Fornecedores.Find(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"Fornecedor with ID {fornecedorId} not found.");

            fornecedor.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void AdicionarPacote(int fornecedorId, Pacote pacote)
        {
            if (pacote == null)
                throw new ArgumentNullException(nameof(pacote));

            var fornecedor = _context.Fornecedores.Find(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"Fornecedor with ID {fornecedorId} not found.");

            fornecedor.Pacotes.Add(pacote);

            _context.SaveChanges();
        }

    }
}

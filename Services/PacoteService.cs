using ConectaEventos.Models;
using ConectaEventos.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{
    public class PacoteService
    {
        private readonly ConectaEventosContext _context;

        public PacoteService(ConectaEventosContext context)
        {
            _context = context;
        }

        public List<Pacote> GetAllPacotes()
        {
            return _context.Pacotes
                .Include(p => p.Fornecedor)
                .Include(p => p.Tema)
                .Include(p => p.PacoteProdutos)
                    .ThenInclude(pp => pp.Produto)
                .AsNoTracking()
                .ToList();
        }

        public Pacote? GetPacoteById(int pacoteId)
        {
            return _context.Pacotes
                .Include(p => p.Fornecedor)
                .Include(p => p.Tema)
                .Include(p => p.PacoteProdutos)
                    .ThenInclude(pp => pp.Produto)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == pacoteId);
        }
    }

}

using ConectaEventos.Data;
using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{
    public class LocalService
    {
        private readonly ConectaEventosContext _context;

        public LocalService(ConectaEventosContext context)
        {
            _context = context;
        }

        public List<Local> GetAllLocais()
        {
            return _context.Locais
            .Include(l => l.Endereco)
            .Include(l => l.Fotos)
            .AsNoTracking()
            .ToList();
        }
    }
}

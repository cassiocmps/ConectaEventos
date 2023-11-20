using ConectaEventos.Data;
using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{

    public class EventoService
    {
        private readonly ConectaEventosContext _context;

        public EventoService(ConectaEventosContext context)
        {
            _context = context;
        }

        public List<Evento> GetAllEventos()
        {
            return _context.Eventos
                .Include(e => e.Cliente)
                .Include(e => e.Local)
                    .ThenInclude(l => l.Fotos)
                .Include(e => e.Pacote)
                    .ThenInclude(p => p.PacoteProdutos)
                        .ThenInclude(pp => pp.Produto)
                .Include(e => e.Tema)
                .Include(e => e.EventoFuncionarios)
                    .ThenInclude(ef => ef.Funcionario)
                .Include(e => e.EventoProdutos)
                    .ThenInclude(pp => pp.Produto)
                .AsNoTracking()
                .ToList();
        }

        public Evento? GetEventoById(int eventoId)
        {
            return _context.Eventos
                .Include(e => e.Cliente)
                .Include(e => e.Local)
                    .ThenInclude(l => l.Fotos)
                .Include(e => e.Pacote)
                    .ThenInclude(p => p.PacoteProdutos)
                        .ThenInclude(pp => pp.Produto)
                .Include(e => e.Tema)
                .Include(e => e.EventoFuncionarios)
                    .ThenInclude(ef => ef.Funcionario)
                .Include(e => e.EventoProdutos)
                    .ThenInclude(pp => pp.Produto)
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == eventoId);
        }

        public List<Evento> GetEventosByClientId(int clientId)
        {
            return _context.Eventos
                .Include(e => e.Cliente)
                .Include(e => e.Local)
                .Include(e => e.Pacote)
                .Include(e => e.Tema)
                .Include(e => e.EventoFuncionarios)
                .Include(e => e.EventoProdutos)
                .AsNoTracking()
                .Where(e => e.ClienteId == clientId)
                .ToList();
        }

        public void AddEvento(Evento evento)
        {
            if (evento == null)
            {
                throw new ArgumentNullException(nameof(evento));
            }

            _context.Eventos.Add(evento);
            _context.SaveChanges();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using ConectaEventos.Data;
using ConectaEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaEventos.Services
{
    public class FuncionarioService
    {
        private readonly ConectaEventosContext _context;

        public FuncionarioService(ConectaEventosContext context)
        {
            _context = context;
        }

        public List<Funcionario> GetAllFuncionarios()
        {
            return _context.Funcionarios
                .Include(f => f.Endereco) // Eager loading of Endereco
                .AsNoTracking()
                .ToList();
        }

        public Funcionario? GetFuncionarioById(int funcionarioId)
        {
            return _context.Funcionarios
                .Include(f => f.Endereco) // Eager loading of Endereco
                .AsNoTracking()
                .FirstOrDefault(f => f.Id == funcionarioId);
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException(nameof(funcionario));
            }

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
    }

}

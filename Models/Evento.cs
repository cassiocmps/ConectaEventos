using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class Evento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateOnly Data { get; set; }

    public decimal ValorTotal { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
    public int ClienteId { get; set; }

    public virtual Local Local { get; set; } = null!;
    public int LocalId { get; set; }
    
    public virtual Pacote? Pacote { get; set; }
    public int? PacoteId { get; set; }
    
    public virtual Tema? Tema { get; set; }
    public int? TemaId { get; set; }

    public virtual ICollection<EventoFuncionario> EventoFuncionarios { get; set; } = new List<EventoFuncionario>();

    public virtual ICollection<EventoProduto> EventoProdutos { get; set; } = new List<EventoProduto>();
}

using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Evento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateOnly Data { get; set; }

    public decimal ValorTotal { get; set; }

    public int? TemaId { get; set; }

    public int? PacoteId { get; set; }

    public int LocalId { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<EventoHasProduto> EventoHasProdutos { get; set; } = new List<EventoHasProduto>();

    public virtual Local Local { get; set; } = null!;

    public virtual Pacote? Pacote { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual Tema? Tema { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}

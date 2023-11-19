using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Pagamento
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateOnly Data { get; set; }

    public int CodAutenticacao { get; set; }

    public int EventoId { get; set; }

    public virtual Evento Evento { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class EventoHasProduto
{
    public int EventoId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class EventoProduto
{
    public int EventoId { get; set; }
    public virtual Evento Evento { get; set; }

    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class EventoProduto
{
    [JsonIgnore]
    public virtual Evento Evento { get; set; }
    public int EventoId { get; set; }

    [JsonIgnore]
    public virtual Produto Produto { get; set; }
    public int ProdutoId { get; set; }
}

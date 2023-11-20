using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class PacoteProduto
{
    [JsonIgnore]
    public virtual Pacote Pacote { get; set; }
    public int IdPacote { get; set; }

    [JsonIgnore]
    public virtual Produto Produto { get; set; }
    public int IdProduto { get; set; }

    public int Quantidade { get; set; }
}

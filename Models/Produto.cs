using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    [JsonIgnore]
    public virtual Fornecedor Fornecedor { get; set; } = null!;
    public int FornecedorId { get; set; }
}

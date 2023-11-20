using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConectaEventos.Models;

public class Pacote
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    [JsonIgnore]
    public virtual Fornecedor? Fornecedor{ get; set; }
    public int FornecedorId { get; set; }

    [JsonIgnore]
    public virtual Tema? Tema { get; set; }
    public int? TemaId { get; set; }

    public virtual ICollection<PacoteProduto> PacoteProdutos { get; set; } = new List<PacoteProduto>();
}

using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int FornecedorId { get; set; }

    public virtual ICollection<EventoHasProduto> EventoHasProdutos { get; set; } = new List<EventoHasProduto>();

    public virtual Fornecedor Fornecedor { get; set; } = null!;

    public virtual ICollection<PacoteHasProduto> PacoteHasProdutos { get; set; } = new List<PacoteHasProduto>();
}

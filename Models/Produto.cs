using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int FornecedorId { get; set; }
    public virtual Fornecedor Fornecedor { get; set; } = null!;
}

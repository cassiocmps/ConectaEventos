using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public partial class PacoteHasProduto
{
    public int PacoteId { get; set; }

    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public virtual Pacote Pacote { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ConectaEventos.Models;

public class PacoteProduto
{
    public int IdPacote { get; set; }
    public virtual Pacote Pacote { get; set; }

    public int IdProduto { get; set; }
    public virtual Produto Produto { get; set; }

    public int Quantidade { get; set; }
}
